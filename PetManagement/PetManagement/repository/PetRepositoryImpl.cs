using Newtonsoft.Json;
using PetManagement.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.repository
{
    public class PetRepositoryImpl : PetRepository
    {
        private static PetRepositoryImpl instance;
        public static PetRepositoryImpl Instance { get { if (instance == null) { instance = new PetRepositoryImpl(); }return instance; } private set => instance = value; }
        public PetRepositoryImpl() { }  
        public List<Pet> FindPet(Func<Pet, Pet> petDelegate, List<Pet> listPet)
        {
            List<Pet> listPets= new List<Pet>();
            foreach (var item in listPet)
            {
                if (petDelegate(item) != null)
                {
                    listPets.Add(petDelegate(item));
                }
            }
            return listPets;
        }
        public List<Pet> ReadToFilePet(string path)
        {
            List<Pet> listPet = new List<Pet>();
            string json= File.ReadAllText(path);
            listPet = JsonConvert.DeserializeObject<List<Pet>>(json);
            return listPet;
        }
        public List<Employee> ReadToFileEmployee(string path)
        {
            List<Employee> listEmployee = new List<Employee>();
            string json = File.ReadAllText(path);
            listEmployee = JsonConvert.DeserializeObject<List<Employee>>(json);
            return listEmployee;    
        }
        public List<Category> ReadToFileCategory(string path)
        {
            List<Category> listCate = new List<Category>();
            string json= File.ReadAllText(path);    
            listCate=JsonConvert.DeserializeObject<List<Category>>(json);
            return listCate;
        }
        public List<Order> ReadToFileOrder(string path)
        {
            List<Order> listOrder = new List<Order>();
            string json= File.ReadAllText(path);
            listOrder = JsonConvert.DeserializeObject<List<Order>>(json);
            return listOrder;
        }
        public List<OrderDetail> ReadToFileOrderDetail(string path)
        {
            List<OrderDetail> listOrdeDetail = new List<OrderDetail>();
            string json= File.ReadAllText(path);
            listOrdeDetail = JsonConvert.DeserializeObject<List<OrderDetail>>(json);
            return listOrdeDetail;  
        }
        public List<Admin> ReadToFileAdmin(string path)
        {
            List<Admin> listAdmin = new List<Admin>();
            string json= File.ReadAllText(path);
            listAdmin = JsonConvert.DeserializeObject<List<Admin>>(json);
            return listAdmin;
        }
        public Boolean WriteToFileCategory(List<Category> listCategory, string path)
        {
            string json = JsonConvert.SerializeObject(listCategory);
            try
            {
                File.WriteAllText(path, json);  
                return true;
            }
            catch
            {
                Console.WriteLine("Error at write to file (Category) !!");
                return false;
            }
        }
        public Boolean WriteToFilePet(List<Pet> listPet, string path)
        {
            string json = JsonConvert.SerializeObject(listPet);
            try
            {
                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                Console.WriteLine("Error at write to file.");
                return false;
            }
        }
        public Boolean WriteToFileEmployee(List<Employee> list, string path){
            Boolean check = false;
            string json= JsonConvert.SerializeObject(list);
            try
            {
                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                Console.WriteLine("Error at write to file Employee@@");
                check = false;
            }
            return check;
        }
        public Boolean WriteToFileOrder(List<Order> listOrder, string path)
        {
            string json =JsonConvert.SerializeObject(listOrder);
            Boolean check = false; try
            {
                File.WriteAllText(path, json);
                check = true;
            }catch
            { 
                Console.WriteLine("Error at Write to file Order @@");
                check = false;
            }
            return check;
        }
        public Boolean WriteToFileOrderDtail(List<OrderDetail> listOrderDetail, string path)
        {
            string json = JsonConvert.SerializeObject(listOrderDetail);
            Boolean check = false; try
            {
                File.WriteAllText(path, json);
                check = true;
            }
            catch
            {
                Console.WriteLine("Error at Write to file OrderDetail @@");
                check = false;
            }
            return check;
        }
        public Boolean WriteToFileAdmin(List<Admin> listAdmin,string path)
        {
            string json=JsonConvert.SerializeObject(listAdmin);
            try
            {
                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                Console.WriteLine("Error at PetRepository @@");
                return false;
            }
        }
    }
}
