using EmployeeManagementV2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementV2.repository
{
    internal class EmployeeRepository : Repository
    {
        public List<Employee> getByBaseSalary(List<Employee> employees, double from, double to)
        {
            return employees.Where(x => x.BaseSalary >= from && x.BaseSalary <= to).ToList();
        }

        public Employee getById(List<Employee> employeeList, int id)
        {
            return employeeList.First(x => x.Id == id);
        }

        public List<Employee> getByName(List<Employee> employeeList, string name)
        {
            return employeeList.Where(x => x.Name.Contains(name)).ToList();
        }

        public List<Employee> getByPosition(List<Employee> employeeList, string position)
        {
            return employeeList.Where(x=>x.Position == position).ToList();
        }

        public List<Employee> getBySalary(List<Employee> employees, double froms, double to)
        {
            return (from e in employees where e.getSalary() >= froms && e.getSalary() <= to select e).ToList(); 
        }
    }
}
