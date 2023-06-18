using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Extensions;
using Services.Interfaces;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketService _basketService;
        private readonly IProductService _productService;

        public BasketController(IBasketService basketService, IProductService productService)
        {
            _basketService = basketService;

            _productService = productService;
        }
        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDTO>> GetBasket()
        {
            var basket = await _basketService.GetBasketAsync(Request.Cookies["buyerId"]);

            if (basket == null) return NotFound();

            return basket.MapBasketToDto();
        }
        [HttpPost]
        public async Task<ActionResult> AddItemToBasket(int productId, int quantity)
        {
            var basket = await _basketService.GetBasketAsync(Request.Cookies["buyerId"]);

            if (basket == null) { basket = await _basketService.CreateBasketAsync(); Response.Cookies.Append("buyerId", basket.BuyerId); }

            var product = await _productService.GetByIdAsync(productId);

            if (product == null) return BadRequest(new ProblemDetails { Title = "Product Not Found" });

            var result = await _basketService.AddItemToBasketAsync(product, basket, quantity);

            if (result) return CreatedAtRoute("GetBasket", basket.MapBasketToDto());

            return BadRequest(new ProblemDetails { Title = "Problem Saving Item to Basket" });
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {
            var basket = await _basketService.GetBasketAsync(Request.Cookies["buyerId"]);

            if (basket == null) return BadRequest(new ProblemDetails { Title = "Product Not Found" });

            var result = await _basketService.RemoveItemFromBasketAsync(basket, productId, quantity);

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem removing item from basket.." });
        }
    }
}