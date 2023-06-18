using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.DTO;
using Services.Extensions;
using Services.Interfaces;

namespace Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly StoreContext _context;

        public OrderService(StoreContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<OrderDTO>>> GetOrdersAsync(string name)
        {
            return await _context.Orders
                .ProjectOrderToDTO()
                .Where(x => x.BuyerId == name)
                .ToListAsync();
        }

        public async Task<ActionResult<OrderDTO>> GetOrderByIdAsync(int id, string name)
        {
            return await _context.Orders
                .ProjectOrderToDTO()
                .Where(x => x.BuyerId == name && x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}