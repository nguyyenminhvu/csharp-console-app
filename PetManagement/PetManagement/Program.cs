using PetManagement.controller;
using PetManagement.service;
using System;
using System.Threading.Tasks;

namespace PetManagement
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            MainController.Instance.AuthorizationController();
         //   EmployeeService.Instance.ShowOrder();
        }
    }
}
