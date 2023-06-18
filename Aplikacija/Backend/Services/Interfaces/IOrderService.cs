using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Microsoft.AspNetCore.Mvc;
using Services.DTO;

namespace Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> AddOrder(Order order);
        public Task<ActionResult<OrderDTO>> GetOrderByIdAsync(int id, string name);
        public Task<ActionResult<List<OrderDTO>>> GetOrdersAsync(string name);
    }
}