using AccountManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.service
{
    public  class KeyService
    {
        private static KeyService instance;
        public KeyService() { }

        public static KeyService Instance { get { if (instance == null) { instance = new KeyService(); }return instance; } private set => instance = value; }

        public Boolean checkKey(string username, string password)
        {
            Boolean check = true;
            Key key = new Key();
            if (!key.Username.Equals(username))
            {
                check=false;
            }else if (!key.Password.Equals(password))
            {
                check = false;
            }
            return check;
        }
    }
}
