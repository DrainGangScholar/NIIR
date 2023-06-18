using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;
using Services.Extensions;
using Services.ExternalServices;
using Services.Interfaces;

namespace API.Controllers
{
    public class PaymentsController : BaseApiController
    {
        private readonly PaymentService _paymentService;
        private readonly StoreContext _context;
        private readonly IBasketService _basketService;

        public PaymentsController(PaymentService paymentService, StoreContext context, IBasketService basketService)
        {
            _paymentService = paymentService;

            _context = context;

            _basketService = basketService;
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BasketDTO>> CreateUpdatePaymentIntent()
        {
            var basket = await _basketService.GetBasketAsync(Request.Cookies["buyerId"]);

            if (basket == null) return NotFound();

            var intent = await _paymentService.CreateOrUpdatePaymentIntent(basket);

            if (intent == null) return BadRequest(new ProblemDetails { Title = "Problem creating payment intent" });

            var result = await _basketService.CreateOrUpdatePaymentIntent(basket, intent);

            if (!result) return BadRequest(new ProblemDetails { Title = "Problem updating basket with intent" });

            return basket.MapBasketToDto();
        }
        [HttpPost("webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            await _paymentService.HandleStripeWebhook(HttpContext.Request);
            
            return new EmptyResult();
        }
    }
}