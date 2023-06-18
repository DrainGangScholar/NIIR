using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItem> Items { get; set; } = new();
        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public void AddItem(Product product, int quantity)
        {
            var existingItem = Items.FirstOrDefault(item => item.Product.Id == product.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                Items.Add(new BasketItem { Product = product, Quantity = quantity });
            }
        }
        public void RemoveItem(int productId, int quantity)
        {
            var item = Items.FirstOrDefault(item => item.Product.Id == productId);

            if (item == null) return;

            item.Quantity -= quantity;

            if (item.Quantity == 0) Items.Remove(item);
        }
    }
}