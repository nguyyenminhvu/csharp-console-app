using CourseManagement;
using EmployeeManagementV2.controller;
using EmployeeManagementV2.service;
using System;

namespace EmployeeManagementV2.view
{
    internal class Program
    {
        private static Validations validations= new Validations();
        private static EmployeeController employeeController = new EmployeeController();   

        static void Main(string[] args)
        {
            int choice;
            Boolean check= true;
            employeeController.init();
            while (check)
            {
                Console.WriteLine("1. Printf All");
                Console.WriteLine("2. Find By ID. ");
                Console.WriteLine("3. Find By Name.");
                Console.WriteLine("4. Find BaseSalary By Range.");
                Console.WriteLine("5. Find Salary By Range.");
                Console.WriteLine("6. Cut.");
                choice = validations.inputInteger("Choice? ", 1, 6);
                switch (choice)
                {
                    case 1: employeeController.printf(); break;
                    case 2: employeeController.findById(); break;
                    case 3: employeeController.findByName();break;
                    case 4:employeeController.findBaseSalary(); break;
                    case 5: employeeController.findSalary(); break;
                    case 6: check= false; break;
                }
            }
        }
    }
}
