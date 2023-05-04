using PetManagement.model;
using PetManagement.repository;
using PetManagement.service;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.controller
{
    public class MainController
    {
        private static List<Employee> listEmployee = new List<Employee>();
        private static List<Admin> listAdmin= new List<Admin>();
        public MainController() { }

        private static MainController instance;
        public static MainController Instance { get { if (instance == null) { instance = new MainController(); }return instance;} private set => instance = value; }
        public void AuthorizationController()
        {
            string username;
            string password;
            listEmployee.Clear();
            listAdmin.Clear();
            listEmployee = PetRepositoryImpl.Instance.ReadToFileEmployee(@"Employee.txt");
            listAdmin = PetRepositoryImpl.Instance.ReadToFileAdmin(@"Admin.txt");
            if(listEmployee!=null &&  listEmployee.Count > 0 ) {
                string role ="";
                Employee employee = null;
                Admin admin = null;
                while (true)
                {
                    username = Validations.Instance.inputString("Username?");
                    password=Validations.Instance.inputString("Password?");
                    employee= listEmployee.GetEmployeeByUsername(username, password);
                    if (employee != null)
                    {
                        role = employee.Role;
                        break;
                    }
                    else
                    {
                        admin=listAdmin.GetAdminByAccount(username,password);
                        if (admin != null)
                        {
                            role= admin.Role;   
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid account @@");
                        }
                    }
                }
                if (role.Equals("EMPLOYEE"))
                {
                    EmployeeController.Instance.EmployeeFeature();
                }else if (role.Equals("ADMIN")){
                    AdminController.Instance.AdminFeature();
                }
                else
                {
                    Console.WriteLine("Your action not support @@");
                }
            }
            else
            {
                Console.WriteLine("List Employee is empty @@");
            }
        }

    }
}
