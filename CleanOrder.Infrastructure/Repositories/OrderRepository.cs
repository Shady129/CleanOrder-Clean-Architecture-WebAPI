using CleanOrder.Application;
using CleanOrder.Domain.Entities;
using CleanOrder.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Infrastructure.Repositories
{
    public class OrderRepository: IOrderRepository
    {

        private readonly AppDbContext _context;


        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<Order?> GetByIdAsync(int id)
        {

            return await _context.Orders.FindAsync(id);
        }



        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }




        public async Task SaveChangesAsync()
        {

            await _context.SaveChangesAsync();
        }



        public async Task<List<Order>> GetAllAsync()
        {

            return await _context.Orders.ToListAsync();
        }
    }
}
