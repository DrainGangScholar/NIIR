using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace Services.ExternalServices
{
    public class PaymentService
    {
        private readonly IConfiguration _config;

        private readonly StoreContext _context;

        public PaymentService(IConfiguration config,StoreContext context)
        {
            _context=context;
            _config = config;
        }
        public async Task<PaymentIntent> CreateOrUpdatePaymentIntent(Basket basket)
        {
            StripeConfiguration.ApiKey = _config["StripeSettings:SecretKey"];
            var service = new PaymentIntentService();
            var intent = new PaymentIntent();
            var subtotal = basket.Items.Sum(item => item.Quantity * item.Product.Price);
            var deliveryFee = subtotal > 5000 ? 0 : 500;
            if (string.IsNullOrEmpty(basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = subtotal + deliveryFee,
                    Currency = "eur",
                    PaymentMethodTypes = new List<string>() { "card" }
                };
                intent = await service.CreateAsync(options);
                // basket.PaymentIntentId = intent.Id;
                // basket.ClientSecret = intent.ClientSecret;
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = subtotal + deliveryFee
                };
                await service.UpdateAsync(basket.PaymentIntentId, options);
            }
            return intent;
        }
        public async Task HandleStripeWebhook(HttpRequest request)
        {
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json, request.Headers["Stripe-Signature"],
                _config["StripeSettings:WhSecret"]);

            var charge = (Charge)stripeEvent.Data.Object;

            var order = await _context.Orders.FirstOrDefaultAsync(x =>
                x.PaymentIntentId == charge.PaymentIntentId);

            if (charge.Status == "succeeded")
            {
                order.OrderStatus = OrderStatus.PaymentReceived;
            }

            await _context.SaveChangesAsync();
        }
    }
}