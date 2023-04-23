using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.model
{
    public class Key
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Key()
        {
            Username = "1";
            Password = "1";
        }
    }
}
