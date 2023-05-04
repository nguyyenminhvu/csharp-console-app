using PetManagement.model;
using PetManagement.repository;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.service
{
    public class AdminService
    {
        private static List<Admin> listAdmin = new List<Admin>();
        public AdminService() { }   
        private static AdminService instance;
        public static AdminService Instance { get { if (instance == null) { instance = new AdminService(); }return instance; }private set => instance = value; }
        public Boolean CreateAdmin()
        {
            listAdmin.Clear();
            listAdmin = PetRepositoryImpl.Instance.ReadToFileAdmin(@"Admin.txt");
            int id;
            try
            {
                if (listAdmin == null || listAdmin.Count == 0)
                {
                    id= 0;
                    listAdmin = new List<Admin>();
                }
                else
                {
                    id = listAdmin.GeneratorId();
                }
                string name = Validations.Instance.inputString("Name admin?");
                string username;
                while(true) {
                    username = Validations.Instance.inputString("Username?");
                    if(listAdmin==null || listAdmin.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        if (listAdmin.GetAdminByUserName(username) == null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Username already exist !");
                        }
                    }
                }
                string role = "ADMIN";
                string password;
                while (true)
                {
                    password = Validations.Instance.inputString("Password?");
                    if(password.Length<3 || password.Length > 15)
                    {
                        Console.WriteLine("Password must be [3-15]");
                    }
                    else
                    {
                        break;
                    }
                }
                listAdmin.Add(new Admin(id, name, username, password, role));
                if (PetRepositoryImpl.Instance.WriteToFileAdmin(listAdmin, @"Admin.txt")){
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Error at AdminService@@  ");
            }
            return false;
        }
    }
}
