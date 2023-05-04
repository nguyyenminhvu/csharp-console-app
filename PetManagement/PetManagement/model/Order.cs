using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class Order
    {
        public int Id { get; set; }
        public int IdEmployee { get; set; }
        public float TotalMoney { get; set; }
        public DateTime DateCreate { get; set; }

        public Order(int id, int idEmployee, float totalMoney)
        {
            Id = id;
            IdEmployee = idEmployee;
            TotalMoney = totalMoney;
            DateCreate = DateTime.Now.Date;
        }

        public Order()
        {
        }
    }
}
