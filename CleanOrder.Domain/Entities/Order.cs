using CleanOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanOrder.Domain.Entities
{
    public class Order
    {

        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public enOrderStatus Status { get; set; }




        public void Ship()
        {
            if (Status == enOrderStatus.Cancelled)
            {

                throw new InvalidOperationException("Cancelled order cannot be shipped.");
            }

            Status = enOrderStatus.Shipped;
        }



        public void Cancel()
        {
            if(Status == enOrderStatus.Shipped)
            {

                throw new InvalidOperationException("Shipped order cannot be cancelled.");
            }

            Status = enOrderStatus.Cancelled;
        }

    }
}
