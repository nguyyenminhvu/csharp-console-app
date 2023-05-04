using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.model
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Admin() { }

        public Admin(int id, string name, string username, string password, string role)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
