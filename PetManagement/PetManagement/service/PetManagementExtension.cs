using PetManagement.model;
using PetManagement.repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetManagement.service
{
    public static class PetManagementExtension
    {
        public static int GeneratorId(this List<Pet> listPet)
        {
            int count = 0;
            listPet.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
            for(int i = 0; i < listPet.Count; i++)
            {
                if (count != listPet[i].Id)
                {
                    return count;
                }
                if(count == listPet.Count - 1)
                {
                    count = listPet.Count; break;
                }
                count++;
            }
            return count;
        }
        public static int GeneratorId(this List<Employee> listEmployee)
        {
            int count = 0;
            listEmployee.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
            for (int i = 0; i < listEmployee.Count; i++)
            {
                if (count != listEmployee[i].Id)
                {
                    return count;
                }
                if (count == listEmployee.Count - 1)
                {
                    count = listEmployee.Count; break;
                }
                count++;
            }
            return count;
        }
        public static int GeneratorId(this List<Order> listOrder)
        {
            int count = 0;
            listOrder.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
            for (int i = 0; i < listOrder.Count; i++)
            {
                if (count != listOrder[i].Id)
                {
                    return count;
                }
                if (count == listOrder.Count - 1)
                {
                    count = listOrder.Count; break;
                }
                count++;
            }
            return count;
        }
        public static int GeneratorId(this List<Category> listCategory)
        {
            int count = 0;
            listCategory.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
            for (int i = 0; i < listCategory.Count; i++)
            {
                if (count != listCategory[i].Id)
                {
                    return count;
                }
                if (count == listCategory.Count - 1)
                {
                    count = listCategory.Count; break;
                }
                count++;
            }
            return count;
        }
        public static int GeneratorId(this List<Admin> listAdmin)
        {
            int count = 0;
            listAdmin.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
            for (int i = 0; i < listAdmin.Count; i++)
            {
                if (count != listAdmin[i].Id)
                {
                    return count;
                }
                if (count == listAdmin.Count - 1)
                {
                    count = listAdmin.Count; break;
                }
                count++;
            }
            return count;
        }
        public static void ShowCategory(this List<Category> listCategory)
        {
            foreach (Category item in listCategory)
            {
                Console.WriteLine($"Id: {item.Id}, Name: {item.Name}");
            }
        }
        public static void ShowPet(this List<Pet> listPet)
        {
            string vaccin, nameCate;
            List<Category> listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
            Console.WriteLine("*----------------------------------------------------------------------------------------*");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|                                      PET LIST                                          |");
            Console.WriteLine("|                                                                                        |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("| ID |      Name      |   Category   | Dob(Year) | Weight |   Price   |      Vaccine     |");
            Console.WriteLine("|    |                |              |           |        |           |                  |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            foreach (Pet item in listPet)
            {
                vaccin = (item.Vaccin)?"Injected":"Not injected yet";
                nameCate= listCate.GetCategoryById(item.idCate).Name;
                Console.WriteLine("|{0,-3} | {1,-14} | {2,-12} | {3,-9} | {4,-6} | {5,-9} | {6, -16} |", item.Id,item.Name,nameCate,item.Dob,item.Weight,item.Price, vaccin);
                Console.WriteLine("|----------------------------------------------------------------------------------------|");
            }
            Console.WriteLine("\n");
        }
        public static void ShowOrder(this List<Order> listOrder)
        {
            string dateStr;
            List<Category> listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
            Console.WriteLine("*-----------------------------------------------------------*");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|                        ORDER LIST                         |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|-----------------------------------------------------------|");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("| ID | ID Employee |  Total Money  |          Date          |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|-----------------------------------------------------------|");
            foreach (Order item in listOrder)
            {
                dateStr = item.DateCreate.ToString("G");
                Console.WriteLine("|{0,-3} | {1,-11} | {2,-13} | {3,-22} |", item.Id, item.IdEmployee, item.TotalMoney, dateStr);
                Console.WriteLine("|-----------------------------------------------------------|");
            }
            Console.WriteLine("\n");
        }
        public static void ShowBill(this Bill bill)
        {
            string dateStr, vaccin, nameCate;
            List<Category> listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
            Console.WriteLine("\n");
            Console.WriteLine($" BILL ID: {bill.Id}  ");
            Console.WriteLine($" EMPLOYEE ID: {bill.IdEmployee}");
            Console.WriteLine($" DATE TIME: {bill.dateCreate} ");
            Console.WriteLine($" TOTAL MONEY: {bill.totalMoney} ");
            Console.WriteLine($" CUSTOMER NAME: {bill.nameCustomer} ");
            Console.WriteLine($" CUSTOMER PHONE : {bill.phoneCustomer} ");
            Console.WriteLine($" CUSTOMER MAIL : {bill.mailCustomer} ");
            Console.WriteLine(" DETAILS PRODUCT: ");
            Console.WriteLine(" *------------------------------------------------------------------------------------*");
            Console.WriteLine(" | ID |    Name    |   Category   | Dob(Year) | Weight |   Price   |      Vaccine     |");
            Console.WriteLine(" |    |            |              |           |        |           |                  |");
            Console.WriteLine(" |------------------------------------------------------------------------------------|");
            foreach (Pet item in bill.listPet)
            {
                vaccin = (item.Vaccin) ? "Injected" : "Not injected yet";
                nameCate = listCate.GetCategoryById(item.idCate).Name;
                Console.WriteLine(" |{0,-3} | {1,-10} | {2,-12} | {3,-9} | {4,-6} | {5,-9} | {6, -16} |", item.Id, item.Name, nameCate, item.Dob, item.Weight, item.Price, vaccin);
                Console.WriteLine(" |------------------------------------------------------------------------------------|");
            }
        }
        public static void ShowEmployee(this List<Employee> listEmployee)
        {
            string status;
            List<Category> listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
            Console.WriteLine("*-------------------------------------------------------------------------------------------*");
            Console.WriteLine("|                                       EMPLOYEE LIST                                       |");
            Console.WriteLine("|                                                                                           |");
            Console.WriteLine("|-------------------------------------------------------------------------------------------|");
            Console.WriteLine("|ID  |      Name      |    Username    |  Password  |    Role    |    Phone    |   Status   |");
            Console.WriteLine("|    |                |                |            |            |             |            |");
            Console.WriteLine("|-------------------------------------------------------------------------------------------|");
            foreach (Employee item in listEmployee)
            {
                status = (item.Status) ? "Active" : "Inactive";
                Console.WriteLine("|{0,-3} | {1,-14} | {2,-14} | {3,-10} | {4,-10} | {5,-11} | {6,-10} |", item.Id, item.Name, item.Username, "*******", item.Role, item.Phone, status);
                Console.WriteLine("|-------------------------------------------------------------------------------------------|");
            }
            Console.WriteLine("\n");
        }
        public static int GetIndexIdCategory(this List<Category> listCategory, Category category) {
            int count = 0;
            foreach (Category item in listCategory)
            {
                if (item.Id.Equals(category.Id))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        public static int GetIndexIdPet(this List<Pet> listPet, Pet pet)
        {
            int count = 0;
            foreach (Pet item in listPet)
            {
                if (item.Id.Equals(pet.Id))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        public static int GetIndexEmployee(this List<Employee> listEmployee, Func<Employee, Boolean> delegateIndex)
        {
            int count = 0;
            foreach (Employee item in listEmployee)
            {
                if (delegateIndex(item))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        public static Category GetCategoryById(this List<Category> listCategory, int id)
        {
            foreach (Category item in listCategory)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }
        public static Pet GetPetById(this List<Pet> listPet, int id)
        {
            foreach (Pet item in listPet)
            {
                if (item.Id.Equals(id))
                {
                    return item;
                }
            }
            return null;
        }
        public static Employee GetEmployeeByUsername(this List<Employee> listEmployee, string username, string password)
        {
            foreach(Employee item in listEmployee)
            {
                if(item.Username.Equals(username) && item.Password.Equals(password)) {
                    return item;
                }
            }
            return null;
        }
        public static Admin GetAdminByUserName(this List<Admin> listAdmin, string username)
        {
            foreach (Admin item in listAdmin)
            {
                if (item.Username.Equals(username))
                {
                    return item;
                }
            }
            return null;
        }
        public static Admin GetAdminByAccount(this List<Admin> listAdmin, string username, string password)
        {
            foreach (Admin item in listAdmin)
            {
                if(item.Username.Equals(username) && item.Password.Equals(password))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
