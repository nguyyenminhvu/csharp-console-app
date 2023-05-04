using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public int PetId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public OrderDetail(int orderId, int petId, float price)
        {
            OrderId = orderId;
            PetId = petId;
            Quantity = 1;
            Price = price;
        }
    }
}
