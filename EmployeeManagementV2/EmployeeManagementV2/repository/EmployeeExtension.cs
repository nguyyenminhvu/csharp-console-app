using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagementV2.model;

namespace EmployeeManagementV2.repository
{
    public static class EmployeeExtension
    {
        public static void GetAll(this List<Employee> listEmployee)
        {
            if (listEmployee != null)
            {
                foreach (var item in listEmployee)
                {
                    Console.WriteLine(item.ToString() + $", Salary: {item.getSalary()}");
                }
            }
 
        }
        public static void getPrimaryObject(this Employee employee, int count = 1)
        {
          if(employee != null)
            {
                Console.WriteLine(employee.ToString() + $", Salary: {employee.getSalary()}");
            }  
        }
    }
}
