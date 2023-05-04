using MimeKit;
using PetManagement.model;
using PetManagement.repository;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PetManagement.service
{
    public class EmployeeService
    {
        private static EmployeeService instance;
        private static List<Employee> listEmployee = new List<Employee> ();    
        private static List<Pet> listPet = new List<Pet> ();
        private static List<Order> listOrder = new List<Order> ();  
        private static List<OrderDetail> listOrderDetail = new List<OrderDetail> ();
        public static EmployeeService Instance { get { if (instance == null) { instance = new EmployeeService(); } return instance; } private set => instance = value; }
        public EmployeeService() { }    
        public Boolean AddEmployee()
        {
            listEmployee.Clear();
            listEmployee = PetRepositoryImpl.Instance.ReadToFileEmployee(@"Employee.txt");
            listEmployee.ShowEmployee();
            Boolean checkO = false;
            try
            {
                int id;
                if (listEmployee==null || listEmployee.Count == 0)
                {
                    id = 0;
                }
                else
                {
                    id = listEmployee.GeneratorId();
                }
                string name = Validations.Instance.inputString("Name employee ?");
                string username;
                while (true)
                {
                    username = Validations.Instance.inputString("Username employee?");
                    if(listEmployee==null || listEmployee.Count == 0)
                    {
                        break;
                    }
                    else
                    {
                        int index = listEmployee.GetIndexEmployee(x =>
                        {
                            Boolean check = false;
                            if (x.Username.Equals(username))
                            {
                                return true;
                            }
                            return check;
                        });
                        if (index < 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Duplicated @@");
                        }
                    }
                }
                string password;
                while (true)
                {
                    password = Validations.Instance.inputString("Password employee?");
                    if(password.Length > 6) {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password length > 6 please @@");
                    }
                }
                string phone;
                while (true)
                {
                    phone = Validations.Instance.inputString("Phone employee?");
                    if(int.TryParse(phone, out int tempPhone) && phone.Length<=11 && phone.Length >=9) {
                        break;
                    }
                    else
                    {
                        if (phone.Length >= 11 || phone.Length <= 9)
                        {
                            Console.WriteLine("Phone [9-10] @@");
                        }
                        else
                        {
                            Console.WriteLine("Integer please @@");
                        }
                    }
                }
                Employee employee = new Employee(id,name,username,password,phone);
                if(listEmployee == null) {
                    listEmployee = new List<Employee>();
                }
                listEmployee.Add(employee);
                if (PetRepositoryImpl.Instance.WriteToFileEmployee(listEmployee, @"Employee.txt"))
                {
                    Console.WriteLine("Added Successfull !!");
                    checkO = true;
                }
            }
            catch
            {
                Console.WriteLine("Error at add employee @@");
            }
           
            return checkO;
        }
        public Boolean UpdateEmployee()
        {
            Boolean check = false;
            listEmployee.Clear();
            listEmployee = PetRepositoryImpl.Instance.ReadToFileEmployee(@"Employee.txt");
            try
            {
                if (listEmployee != null)
                {
                    listEmployee.ShowEmployee();
                    int id, index;
                    while (true)
                    {
                        id = Validations.Instance.inputInteger("ID employee update?", 0, 999);
                        index = listEmployee.GetIndexEmployee(x =>
                        {
                            Boolean check = false;
                            if (x.Id.Equals(id))
                            {
                                return true;
                            }
                            return check;
                        });
                        if(index >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID employee @@");
                        }
                    }
                    string name = Validations.Instance.inputString("New name employee?");
                    string username;
                    while (true)
                    {
                        username = Validations.Instance.inputString("New username employee?");
                        if (listEmployee == null || listEmployee.Count == 0)
                        {
                            break;
                        }
                        else
                        {
                            int s = listEmployee.GetIndexEmployee(x =>
                            {
                                Boolean check = false;
                                if (x.Username.Equals(username))
                                {
                                    return true;
                                }
                                return check;
                            });
                            if (s < 0)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Duplicated @@");
                            }
                        }
                    }
                    string password;
                    while (true)
                    {
                        password = Validations.Instance.inputString("New password employee?");
                        if (password.Length > 6)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Password length > 6 please @@");
                        }
                    }
                    string phone;
                    while (true)
                    {
                        phone = Validations.Instance.inputString("New phone employee?");
                        if (int.TryParse(phone, out int tempPhone) && phone.Length <= 11 && phone.Length >= 9)
                        {
                            break;
                        }
                        else
                        {
                            if (phone.Length >= 11 || phone.Length <= 9)
                            {
                                Console.WriteLine("Phone [9-10] @@");
                            }
                            else
                            {
                                Console.WriteLine("Integer please @@");
                            }
                        }
                    }
                    Employee employee = new Employee(id, name, username, password, phone);
                    listEmployee[index] = employee;
                    if (PetRepositoryImpl.Instance.WriteToFileEmployee(listEmployee, @"Emoloyee,txt"))
                    {
                        check = true;
                        Console.WriteLine("Updated successful !!");
                    }
                }
                else
                {
                    Console.WriteLine("List employee is empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at update employee @@");
                check = false;
            }
            return check;
        }
        public Boolean RemoveEmployee()
        {
            Boolean check = false;
            listEmployee.Clear();
            listEmployee = PetRepositoryImpl.Instance.ReadToFileEmployee(@"Employee.txt");
            try
            {
                if (listEmployee != null)
                {
                    int id, index;
                    while (true)
                    {
                        listEmployee.ShowEmployee();
                        id = Validations.Instance.inputInteger("ID employee to remove?", 0, 999);
                        index = listEmployee.GetIndexEmployee(x =>
                        {
                            Boolean check = false;
                            if (x.Id.Equals(id))
                            {
                                return true;
                            }
                            return check;
                        });
                        if (index >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID employee @@");
                        }
                    }
                    if (listEmployee[index].Status)
                    {
                        int ans = Validations.Instance.inputInteger("Are your sure (0: No, 1: Yes)?", 0, 1);
                        if (ans == 1)
                        {
                            listEmployee[index].Status = false;
                            if (PetRepositoryImpl.Instance.WriteToFileEmployee(listEmployee, @"Employee.txt"))
                            {
                                check = true;
                                Console.WriteLine("Removed successful !!");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Account not active @@");
                    }
                }
                else
                {
                    Console.WriteLine("List employee is empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at Remove employee @@");
                check = false;
            }
            return check;
        }
        public Bill AddOrder()
        {
            List<Pet> listPetDetail = new List<Pet> ();   
            Boolean check = false;
            listEmployee.Clear();
            listPet.Clear();
            listOrder.Clear();
            listOrderDetail.Clear();
            try
            {
                listEmployee = PetRepositoryImpl.Instance.ReadToFileEmployee(@"Employee.txt");
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                listOrder = PetRepositoryImpl.Instance.ReadToFileOrder(@"Order.txt");
                listOrderDetail = PetRepositoryImpl.Instance.ReadToFileOrderDetail(@"OrderDetail.txt");
                listOrder.ShowOrder();
                if (listPet != null)
                {
                    int idOrder;
                    if (listOrder == null)
                    {
                        listOrder = new List<Order>();
                        idOrder=0;
                    }
                    else
                    {
                        idOrder = listOrder.GeneratorId();
                    }
                    listPet.ShowPet();
                    int num = Validations.Instance.inputInteger("Number of pet sale?", 0, listPet.Count-1);
                    float totalMoney=0;
                    for(int i = 0; i < num; i++)
                    {
                        int id;
                        while (true)
                        {
                            id = Validations.Instance.inputInteger($"ID pet {i+1} to sale?", 0, 999);
                            Pet pet = listPet.GetPetById(id);
                            if (pet != null)
                            {
                                listPetDetail.Add(pet);
                                totalMoney += pet.Price;
                                break;
                            }
                        }
                    }
                    int idEmployee, indexEmployee;
                    string username, password;
                    while (true)
                    {
                        
                        username = Validations.Instance.inputString("Username employee confirm?");
                        indexEmployee = listEmployee.GetIndexEmployee(x =>
                        {
                            Boolean check = false;
                            if (x.Username.Equals(username))
                            {
                                return true;
                            }
                            return check;
                        });
                        if (indexEmployee>=0)
                        {
                            idEmployee = listEmployee[indexEmployee].Id;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Username invalid, check again @@");
                        }
                    }
                    while (true)
                    {
                        password = Validations.Instance.inputString("Password employee confirm?");
                        if (listEmployee.GetIndexEmployee(x =>
                        {
                            Boolean check = false;
                            if (x.Password.Equals(password))
                            {
                                return true;
                            }
                            return check;
                        }) >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Password invalid, check again @@");
                        }
                    }
                    Order order = new Order(idOrder, idEmployee,totalMoney);
                    listOrder.Add(order);
                    if (PetRepositoryImpl.Instance.WriteToFileOrder(listOrder, @"Order.txt"))
                    {
                        foreach (Pet item in listPetDetail)
                        {
                            OrderDetail orderDetail = new OrderDetail(idOrder,item.Id,item.Price);
                            if (listOrderDetail == null)
                            {
                                listOrderDetail = new List<OrderDetail>();
                            }
                            listOrderDetail.Add(orderDetail);   
                        }
                        if (PetRepositoryImpl.Instance.WriteToFileOrderDtail(listOrderDetail, @"OrderDetail.txt"))
                        {
                            string customerName = Validations.Instance.inputString("Customer name?");
                            string phoneCustomer;
                            while (true)
                            {
                                phoneCustomer = Validations.Instance.inputString("Customer phone?");
                                if (int.TryParse(phoneCustomer, out int tempPhone) && phoneCustomer.Length <= 11 && phoneCustomer.Length >= 9)
                                {
                                    break;
                                }
                                else
                                {
                                    if (phoneCustomer.Length >= 11 || phoneCustomer.Length <= 9)
                                    {
                                        Console.WriteLine("Phone [9-10] @@");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Integer please @@");
                                    }
                                }
                            }
                            string customerEmail = Validations.Instance.inputString("Customer email?");
                            Console.WriteLine("Create Order Successful !!");
                            Bill bill = new Bill(idOrder, listPetDetail, totalMoney,customerName,phoneCustomer,idEmployee,customerEmail,DateTime.Now);
                            SendMail(bill);
                            return bill;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("List pet is empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at add order pet@@");
            }
            return null;
        }
        public void ShowOrder()
        {
            listOrder.Clear();
            listOrder = PetRepositoryImpl.Instance.ReadToFileOrder(@"Order.txt");
            listOrder.ShowOrder();
        }
        public  async void SendMail(Bill bill)
        {
            try
            {
                var mimeMail = new MimeMessage();
                mimeMail.From.Add(new MailboxAddress("PET STORE VIP PRO", "sending.test.sendingEmail@gmail.com"));
                mimeMail.To.Add(new MailboxAddress($"{bill.nameCustomer}", $"{bill.mailCustomer}"));
                mimeMail.Subject = "PET STORE SAY THANK YOU !";
                mimeMail.Body = new TextPart("plain")
                {
                    Text = "HELLO! NICE TO MEET YOU TOO"
                };
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        Thread.Sleep(1000);
                        client.AuthenticationMechanisms.Remove("XOAUTH2");
                        Thread.Sleep(1000);
                        client.Authenticate("sending.test.sendingemail@gmail.com", "xlfghbrefrfwegll");
                        Thread.Sleep(1000);
                        client.Send(mimeMail);
                        Thread.Sleep(1000);
                        client.Disconnect(true);
                        Console.WriteLine("Send mail successful! ");
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Send mail fail @@"+e.Message.ToString());
            }
        }
    }
}
