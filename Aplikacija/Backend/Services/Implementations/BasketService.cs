using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;

namespace Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly Infrastructure.Data.StoreContext _context;
        public BasketService(Infrastructure.Data.StoreContext context)
        {
            _context = context;
        }

        public async Task<Basket> GetBasketAsync(string requestCookie)
        {
            return await _context.Baskets
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == requestCookie);
        }

        public async Task<Basket> CreateBasketAsync()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            var basket = new Basket { BuyerId = buyerId };
            await _context.Baskets.AddAsync(basket);
            return basket;
        }

        public async Task<bool> AddItemToBasketAsync(Core.Entities.Product product, Basket basket, int quantity)
        {
            basket.AddItem(product, quantity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveItemFromBasketAsync(Basket basket, int productId, int quantity)
        {
            basket.RemoveItem(productId, quantity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateOrUpdatePaymentIntent(Basket basket, Stripe.PaymentIntent intent)
        {
            basket.PaymentIntentId = basket.PaymentIntentId ?? intent.Id;

            basket.ClientSecret = basket.ClientSecret ?? intent.ClientSecret;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveBasket(Basket basket)
        {
            foreach (var item in basket.Items)
            {
                _context.Remove(item);
            }

            _context.Remove(basket);

            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> RemoveItemInBaskets(Product product)
        {
            var baskets = await _context.Baskets
                .Where(b => b.Items.Any(p => p.Product.Id == product.Id))
                .Include(b => b.Items)
                .ToListAsync();

            if (baskets.Count == 0)
            {
                return false;
            }

            foreach (var basket in baskets)
            {
                var itemsToRemove = basket.Items.Where(item => item.Product.Id == product.Id).ToList();
                foreach (var item in itemsToRemove)
                {
                    basket.Items.Remove(item);
                }
            }

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
