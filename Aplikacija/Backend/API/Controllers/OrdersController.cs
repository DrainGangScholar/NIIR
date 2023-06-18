using Core.Entities.OrderAggregate;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Extensions;
using Services.Interfaces;

namespace API.Controllers
{
    [Authorize]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;
        private readonly IAccountService _userService;

        public StoreContext _context { get; }

        public OrdersController(StoreContext context, IOrderService orderService,
        IBasketService basketService, IProductService productService
        , IAccountService userService)
        {
            _context = context;
            _orderService = orderService;
            _basketService = basketService;
            _productService = productService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrders()
        {
            return await _orderService.GetOrdersAsync(User.Identity.Name);
        }

        [HttpGet("{id}", Name = "GetOrder")]
        public async Task<ActionResult<OrderDTO>> GetOrder(int id)
        {
            return await _orderService.GetOrderByIdAsync(id, User.Identity.Name);
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(CreateOrderDTO orderDTO)
        {
            var basket = await _basketService.GetBasketAsync(Request.Cookies["buyerId"]);

            if (basket == null) return BadRequest(new ProblemDetails { Title = "Could not locate basket" });

            var items = new List<OrderItem>();

            var order = Order.CreateOrder(User.Identity.Name);

            order.AddOrderItems(basket.Items);

            var result = await _basketService.RemoveBasket(basket);

            if (!result) return BadRequest("Problem removing basket");

           if (orderDTO.SaveAddress)
           {
               var user = await _userService.GetUserAsync(User.Identity.Name);
               if(user!=null)
                    user.CreateUpdateAddress(orderDTO.ShippingAddress);
           }
 
            result = await _orderService.AddOrder(order);

            if (result) return CreatedAtRoute("GetOrder", new { id = order.Id }, order.Id);

            return BadRequest("Problem creating order");
        }
    }
}
