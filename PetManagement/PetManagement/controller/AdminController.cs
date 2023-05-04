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
    internal class AdminController
    {
        public AdminController() { }
        private static AdminController instance;

        internal static AdminController Instance { get { if (instance == null) { instance = new AdminController(); }return instance; }private set => instance = value; }

        public void AdminFeature()
        {
            Boolean check = true;
            while (check)
            {
                Console.WriteLine("0. View Pet");
                Console.WriteLine("1. Add Pet");
                Console.WriteLine("2. Update Pet");
                Console.WriteLine("3. Delete Pet");
                Console.WriteLine("4. Create Category");
                Console.WriteLine("5. Create Employee");
                Console.WriteLine("6. Update Employee");
                Console.WriteLine("7. Remove Employee");
                Console.WriteLine("8. Quit");
                int choice = Validations.Instance.inputInteger("Choice?", 0, 8);
                switch (choice)
                {
                    case 0: PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt").ShowPet(); break;
                    case 1: if (!PetService.Instance.AddPet()) { Console.WriteLine("Add fail!"); } break;
                    case 2: if (!PetService.Instance.UpdatePet()) { Console.WriteLine("Update fail!"); } break;
                    case 3: if (!PetService.Instance.RemovePet()) { Console.WriteLine("Remove fail!"); } break;
                    case 4: if (!PetService.Instance.AddCategory()) { Console.WriteLine("Add fail!"); } break;
                    case 5: if (!EmployeeService.Instance.AddEmployee()) { Console.WriteLine("Add fail!"); } break;
                    case 6: if (!EmployeeService.Instance.UpdateEmployee()) { Console.WriteLine("Update fail!"); } break;
                    case 7: if (!EmployeeService.Instance.RemoveEmployee()) { Console.WriteLine("Remove fail!"); } break;
                    case 8: check = false; break;
                }
            }
        }
    }
}
