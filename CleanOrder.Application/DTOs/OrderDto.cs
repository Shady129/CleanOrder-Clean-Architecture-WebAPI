using CleanOrder.Domain.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Application.DTOs
{
    public class OrderDto
    {


        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public enOrderStatus Status { get; set; }

    }
}
