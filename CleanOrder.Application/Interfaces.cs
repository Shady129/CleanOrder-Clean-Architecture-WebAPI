using CleanOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Application
{
    public interface IOrderRepository
    {

        Task<Order?> GetByIdAsync(int id);

        Task AddAsync(Order order);


        Task SaveChangesAsync();


        Task<List<Order>> GetAllAsync();


    }
}
