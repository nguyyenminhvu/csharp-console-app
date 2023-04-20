using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementV2.model
{
    public delegate double CalculatorSalaryDelegate(double baseSalary);
    public delegate double CalculatorSalaryYearDelegate(double salary);
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double BaseSalary { get; set; }
        public CalculatorSalaryDelegate CalculatorSalaryDelegate { get; set;}
        public CalculatorSalaryYearDelegate CalculatorSalaryYearDelegate { get; set; }

        public Employee() { }

        public Employee(int id, string name, string position, double baseSalary)
        {
            Id = id;
            Name = name;
            Position = position;
            BaseSalary = baseSalary;
            setSalaryWithPosition(Position);
        }
        public double getSalary()
        {
            if (BaseSalary != null)
            {
                return CalculatorSalaryDelegate(BaseSalary);
            }
            else
            {
                throw new InvalidOperationException("Not Valid Data!");
            }
          
        }
        public double getSalaryYear()
        {
            double salary = CalculatorSalaryDelegate(BaseSalary);
            return CalculatorSalaryYearDelegate(salary);
        }
        public void setSalaryWithPosition(string Position)
        {   
            switch(Position)
            {
                case "Employee": CalculatorSalaryDelegate = (x => x * 1.2);
                    CalculatorSalaryYearDelegate = (y=>y*12+y); break;  
                case "Boss": CalculatorSalaryDelegate=(x=>x*1.8);
                    CalculatorSalaryYearDelegate = (y => y * 12 + 2.5*y); break;
                case "Middle-Boss": CalculatorSalaryDelegate=(x=>x*1.5);
                    CalculatorSalaryYearDelegate = (y => y * 12 + 1.5 * y); break;
                default: CalculatorSalaryDelegate = null;
                    CalculatorSalaryYearDelegate = null;
                    break;
            }
        }

        public override string ToString()
        {
            return $"ID: {Id}, NAME: {Name}, POSITION: {Position}, BASE-SALARY: {BaseSalary}";
        }
    }
}
