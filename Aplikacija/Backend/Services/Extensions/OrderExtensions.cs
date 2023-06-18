using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Services.Extensions
{
    public static class OrderExtensions
    {
        public static IQueryable<OrderDTO> ProjectOrderToDTO(this IQueryable<Order> query)
        {
            return query
                .Select(order => new OrderDTO
                {
                    Id = order.Id,
                    BuyerId = order.BuyerId,
                    OrderDate = order.OrderDate,
                    ShippingAddress = order.ShippingAddress,
                    DeliveryFee = order.DeliveryFee,
                    Subtotal = order.Subtotal,
                    OrderStatus = order.OrderStatus.ToString(),
                    Total = order.GetTotal(),
                    OrderItems = order.OrderItems.Select(item => new OrderItemDTO
                    {
                        ProductId = item.ItemOrdered.ProductId,
                        Name = item.ItemOrdered.Name,
                        PictureUrl = item.ItemOrdered.PictureUrl,
                        Price = item.Price,
                        Quantity = item.Quantity
                    }).ToList()
                }).AsNoTracking();
        }
        public static void AddOrderItems(this Order order, List<BasketItem> basketItems)
        {
            var items = new List<OrderItem>();

            var products = basketItems.Select(item => item.Product).ToList();

            foreach (var item in basketItems)
            {
                var productItem = products.Find(product => product.Id == item.Product.Id);
                var itemOrdered = new ProductItemOrdered
                {
                    ProductId = productItem.Id,
                    Name = productItem.Name,
                    PictureUrl = productItem.PictureUrl
                };
                var orderItem = new OrderItem
                {
                    ItemOrdered = itemOrdered,
                    Price = productItem.Price,
                    Quantity = item.Quantity
                };
                items.Add(orderItem);
                productItem.QuantityInStock -= item.Quantity;
            }
            order.OrderItems = items;

            var subtotal = items.Sum(item => item.Price * item.Quantity);

            var deliveryFee = subtotal > 5000 ? 0 : 500;

            order.Subtotal = subtotal;

            order.DeliveryFee = deliveryFee;
        }
    }
}