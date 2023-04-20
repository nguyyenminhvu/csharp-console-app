using EmployeeManagementV2.model;
using EmployeeManagementV2.repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeManagementV2.service
{
    internal class EmployeeService
    {
        private static List<Employee> employeeList= new List<Employee>();
        private static Repository repository = new EmployeeRepository();   
        public void readData(string fileName)
        {
            employeeList.Clear();
            StreamReader streamReader = new StreamReader(fileName);
            string line;
            while ((line = streamReader.ReadLine()) != null)
            {
                string[] splitLine = line.Split(",");
                Employee employee = new Employee(Convert.ToInt32(splitLine[0].Trim()), splitLine[1].Trim(), splitLine[2].Trim(), Convert.ToDouble(splitLine[3].Trim())); 
                employeeList.Add(employee); 
            }
            streamReader.Close();
        }
        public void printfAll()
        {
            employeeList.GetAll();
        }
        public Employee getEmployeeById(int id) {
            Employee employee= new Employee();
            employee = repository.getById(employeeList, id);
            if(employee != null) {
                return employee;
            }
            else
            {
                Console.WriteLine($"Not Found Any Employee With ID: {id}");
            }
            return null;
        }
        public List<Employee> getEmployeesByName(string name)
        {
            List<Employee> findByNameList = new List<Employee> ();
            findByNameList = repository.getByName(employeeList, name);
            if(findByNameList.Count >0) {
                return findByNameList;
            }
            else
            {
                Console.WriteLine($"Not Found Any Employee With Name: {name}");
            }
            return null;
        }
        public List<Employee> getEmployeesByRangeBaseSalary(double froms, double to)
        {
            List<Employee> findByBaseSalary = new List<Employee>();
            findByBaseSalary = repository.getByBaseSalary(employeeList, froms, to);
            if(findByBaseSalary.Count > 0)
            {
                return findByBaseSalary;
            }
            else
            {
                Console.WriteLine($"Not Found Any Employee With Range BaseSalary From: {froms} To: {to}");
            }
            return null;
        }
        public List<Employee> getEmployeesBySalary(double froms, double to)
        {
             List<Employee> findBySalary = new List<Employee>();
            findBySalary = repository.getBySalary(employeeList, froms, to); 
            if (findBySalary.Count > 0) { return findBySalary; } else
            {
                Console.WriteLine($"Not Found Any Employee With Range Salary From: {froms} To: {to}");
            }
            return null;
        }

    }
}
