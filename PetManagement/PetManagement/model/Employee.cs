using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class Employee
    {
        public Employee() { }
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public Boolean Status { get; set; }
        public Employee(int id, string name, string username, string password, string phone)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Role = "EMPLOYEE";
            Phone = phone;
            Status = true;
        }
    }
}
