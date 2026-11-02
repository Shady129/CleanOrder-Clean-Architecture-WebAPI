using CleanOrder.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        
        




        
        
        
        }



       
        






    }









}
    

