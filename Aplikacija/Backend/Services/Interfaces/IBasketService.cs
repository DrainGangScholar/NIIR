using Core.Entities;

namespace Services.Interfaces
{
    public interface IBasketService
    {
        public Task<Basket> GetBasketAsync(string requestCookie);
        public Task<Basket> CreateBasketAsync();
        public Task<bool> AddItemToBasketAsync(Core.Entities.Product product, Basket basket, int quantity);
        public Task<bool> RemoveItemFromBasketAsync(Basket basket, int productId, int quantity);
        public Task<bool> CreateOrUpdatePaymentIntent(Basket basket, Stripe.PaymentIntent intent);
        public Task<bool> RemoveBasket(Basket basket);
        public Task<bool> RemoveItemInBaskets(Product product);
    }
}
