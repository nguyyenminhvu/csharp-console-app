using EmployeeManagementV2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementV2.repository
{
    public interface Repository
    {

        public Employee getById(List<Employee> employeeList, int id);
        public List<Employee> getByName(List<Employee> employeeList, string name);
        public List<Employee> getByPosition(List<Employee> employeeList, string position);
        public List<Employee> getByBaseSalary(List<Employee> employees, double from, double to);
        public List<Employee> getBySalary(List<Employee> employees, double from, double to);


    }
}
