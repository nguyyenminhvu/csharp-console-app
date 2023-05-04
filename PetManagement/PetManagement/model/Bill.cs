using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class Bill
    {
        public Bill() { }   
        public int Id { get; set; } 
        public List<Pet> listPet { get; set; }
        public float totalMoney { get; set; }
        public string nameCustomer { get; set; }
        public int IdEmployee { get; set; }
        public string phoneCustomer { get; set; }
        public DateTime dateCreate { get; set; }
        public string mailCustomer { get; set; }

        public Bill(int id, List<Pet> listPet, float totalMoney, string nameCustomer, string phoneCustomer, int idEmployee, string mailCustomer, DateTime dateTime)
        {
            Id = id;
            this.listPet = listPet;
            this.totalMoney = totalMoney;
            this.nameCustomer = nameCustomer;
            this.phoneCustomer = phoneCustomer;
            this.dateCreate = dateTime;
            this.IdEmployee = idEmployee;
            this.mailCustomer = mailCustomer;
        }
    }
}
