using CleanOrder.Domain.Entities;
using CleanOrder.Domain.Enums;
using CleanOrder.Application.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Application.Services
{
    public class OrderService
    {

        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }



        public async Task ShipOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                throw new InvalidOperationException("Order not found.");


            order.Ship();


            await _orderRepository.SaveChangesAsync();
        }



        public async Task CancelOrderAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                throw new InvalidOperationException("Order not found.");

            order.Cancel();

            await _orderRepository.SaveChangesAsync();
        }



        public async Task CreateOrderAsync()
        {
            var order = new Order
            {
                CreatedAt = DateTime.UtcNow
            };

            order.Status = enOrderStatus.Pending;

            await _orderRepository.AddAsync(order);

            await _orderRepository.SaveChangesAsync();
        }



        public async Task<List<OrderDto?>> GetAllOrdersAsync()
        {
            var orders =  await _orderRepository.GetAllAsync();

            var orderDtos = orders.Select(order => new OrderDto
            {

                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status

            }).ToList();


            return orderDtos;
        }



        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetByIdAsync(id);


            if (order == null)
            {
                return null;
            }

            return new OrderDto
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Status = order.Status
            };
        }






    }
}
