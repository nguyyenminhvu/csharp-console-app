using CourseManagement;
using EmployeeManagementV2.repository;
using EmployeeManagementV2.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementV2.controller
{  
    internal class EmployeeController
    {
        private static EmployeeService employeeService = new EmployeeService();
        private static Validations validations = new Validations();
        public void init()
        {
            employeeService.readData(@"EmployeeList.txt");
        }
        public void printf()
        {
           employeeService.printfAll();
        }
        public void findById()
        {
            int id = validations.inputInteger("ID Please: ",1,9999);
            employeeService.getEmployeeById(id).getPrimaryObject();
        }
        public void findByName()
        {
            string name = validations.inputString("Name Please: ");
            employeeService.getEmployeesByName(name).GetAll();
        }
        public void findBaseSalary()
        {
            double froms = validations.inputDouble("BaseSalary From: ", 1, 9999);
            double to = validations.inputDouble("BaseSalary To: ", froms, 9999);
            employeeService.getEmployeesByRangeBaseSalary(froms, to).GetAll();   
        }
        public void findSalary()
        {
            double froms = validations.inputDouble("Salary From: ", 1, 9999);
            double to = validations.inputDouble("Salary To: ", froms, 9999);
            employeeService.getEmployeesBySalary(froms, to).GetAll();    
        }
        
    }
}
