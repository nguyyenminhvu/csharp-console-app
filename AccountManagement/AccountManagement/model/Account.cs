using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.model
{
    public class Account
    {
        public Account() { }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public int  Idcategory { get; set; }

        public Account(int id, string username, string password, int idcategory)
        {
            Id = id;
            Username = username;
            Password = password;
            Idcategory = idcategory;
        }
    }
}
