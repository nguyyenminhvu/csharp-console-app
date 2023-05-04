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
    public class EmployeeController
    {
        public EmployeeController() { } 
        private static EmployeeController instance;

        public static EmployeeController Instance { get { if (instance == null) { instance = new EmployeeController(); }return instance; }private set => instance = value; }

        public void EmployeeFeature()
        {
          Boolean  check=true;   
            while (check)
            {
                Console.WriteLine("0. View Pet");
                Console.WriteLine("1. Create Order");
                Console.WriteLine("2. Quit");
                int choice = Validations.Instance.inputInteger("Choice?", 0, 6);
                switch (choice)
                {
                    case 0: PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt").ShowPet(); break;
                    case 1: Bill bill =EmployeeService.Instance.AddOrder() ; if (bill != null) { bill.ShowBill(); } break;
                    case 2: check = false; break;
                }
            }
        }
    }
}
