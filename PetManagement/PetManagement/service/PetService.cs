using PetManagement.model;
using PetManagement.repository;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PetManagement.service
{

    public class PetService
    {
        private static List<Pet> listPet = new List<Pet>();
        private static List<Category> listCate = new List<Category>();
        public PetService() { }

        private static  PetService instance;
        public static PetService Instance { get { if (instance == null) { instance = new PetService(); } return instance; }private set => instance = value; }
        public Boolean AddPet()
        {
            Boolean check = false;
            try
            {
                listPet.Clear();
                listCate.Clear();
                listPet = PetRepositoryImpl.Instance.ReadToFilePet("Pet.txt");
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory("Category.txt");
                if (listPet == null)
                {
                    listPet = new List<Pet>();  
                }
                int id = listPet.GeneratorId();
                string name = Validations.Instance.inputString("Name Pet?");
                int dob = Validations.Instance.inputInteger("Year old?", 1, 99);
                int idCate = 0;
                if (listCate.Count > 0)
                {
                    while (true)
                    {
                        listCate.ShowCategory();
                        idCate = Validations.Instance.inputInteger("ID Category?", 0, 999);
                        if (listCate.GetIndexIdCategory(listCate.GetCategoryById(idCate)) >= 0)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID Category !!");
                        }
                    }
                    int numVaccin = Validations.Instance.inputInteger("Vaccin? (0: No, 1:Yes)?", 0, 1);
                    Boolean vaccin = (numVaccin == 0) ? false : true;
                    float weight = Validations.Instance.inputFloat("Weight?", 0, 999);
                    float price = Validations.Instance.inputFloat("Price?", 1, 9999999);
                    Pet pet = new Pet(id,name,dob,idCate,vaccin,weight,price);
                    listPet.Add(pet);
                    if (PetRepositoryImpl.Instance.WriteToFilePet(listPet, "Pet.txt")) {
                        Console.WriteLine("Added Successfull !!");
                        check = true;
                    }
                }
                else
                {
                    AddCategory();
                }
            }
            catch
            {
                Console.WriteLine("Error at add pet @@");
                check = false;
            }
            return check;
        }
        public Boolean AddCategory()
        {
            listCate.Clear();
            listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
            Boolean check = false;
            try
            {
                int id = 0;
                if (listCate !=null && listCate.Count > 0)
                {
                 id=listCate.GeneratorId();
                }
                if (listCate == null)
                {
                    listCate = new List<Category>();
                }
                string name = Validations.Instance.inputString("Name category?");
                Category category = new Category(id, name);
                listCate.Add(category); 
                if (PetRepositoryImpl.Instance.WriteToFileCategory(listCate, @"Category.txt"))
                {
                    Console.WriteLine("Add successfull !!");
                    check = true;
                }
            }
            catch
            {
                Console.WriteLine("Error at add category @@");
                check = false;
            }
            return check;
        }
        public Boolean UpdatePet()
        {
            Boolean check = false;
            try
            {
                listCate.Clear();
                listPet.Clear();
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                if(listPet!= null && listPet.Count > 0)
                {
                    int index;
                    int id;
                    while (true)
                    {
                        listPet.ShowPet();
                        id = Validations.Instance.inputInteger("ID pet to update?", 0, 999);
                        Pet pets = listPet.GetPetById(id);
                        if (pets != null)
                        {
                            index = listPet.GetIndexIdPet(pets);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID pet invalid @@");
                        }
                    }
                    string name = Validations.Instance.inputString("Name Pet to update?");
                    int dob = Validations.Instance.inputInteger("Year old to update?", 1, 99);
                    int idCate = 0;
                    while (true)
                    {
                        listCate.ShowCategory();
                        idCate = Validations.Instance.inputInteger("ID category?", 0, 999);
                        if (listCate.GetCategoryById(idCate) != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid category ID @@");
                        }
                    }
                    int numVaccin = Validations.Instance.inputInteger("Vaccin to update? (0: No, 1:Yes)?", 0, 1);
                    Boolean vaccin = (numVaccin == 0) ? false : true;
                    float weight = Validations.Instance.inputFloat("Weight to update?", 0, 999);
                    float price = Validations.Instance.inputFloat("Price to update?", 1, 9999999);
                    Pet pet = new Pet(id, name, dob, idCate, vaccin, weight, price);
                    listPet[index] = pet;
                    if (PetRepositoryImpl.Instance.WriteToFilePet(listPet, @"Pet.txt"))
                    {
                        Console.WriteLine("Update Successfull !!");
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("List pet empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at update pet @@");
                check = false;
            }
            return check;
        }
        public Boolean UpdateCategory()
        {
            Boolean check = false;
            try
            {
                listCate.Clear();
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                if (listCate != null && listCate.Count>0)
                {
                    int id,index;
                    while (true)
                    { 
                        listCate.ShowCategory();
                        id = Validations.Instance.inputInteger("ID category to update?", 0, 999);
                        Category category = listCate.GetCategoryById(id);
                        if (category != null)
                        {
                            index = listCate.GetIndexIdCategory(category);
                            break;
                        }
                    }
                    string name = Validations.Instance.inputString("New name category?");
                    Category category1 = new Category(id, name);
                    listCate[index]=category1;
                    if(PetRepositoryImpl.Instance.WriteToFileCategory(listCate, @"Category.txt"))
                    {
                        Console.WriteLine("Update successfull !!!");
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("List category is empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at update category !");
                check = false;
            }
            return check;
        }
        public Boolean RemovePet()
        {
            listPet.Clear();
            listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
            Boolean check = false;
            try
            {
                if (listPet != null)
                {
                    int id, index;
                    while (true)
                    {
                        listPet.ShowPet();
                        id = Validations.Instance.inputInteger("Id pet to remove?", 0, 999);
                        Pet pet = listPet.GetPetById(id);
                        if (pet != null)
                        {
                            index = listPet.GetIndexIdPet(pet);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID pet @@");
                        }
                    }
                    listPet.RemoveAt(index);
                    if (PetRepositoryImpl.Instance.WriteToFilePet(listPet, @"Pet.txt"))
                    {
                        Console.WriteLine("Removed !!");
                        check = true;
                    }
                }
                else
                {
                    Console.WriteLine("List pet is empty");
                }
            }
            catch
            {
                Console.WriteLine("Error at remove pet @@");
                check = false;
            }
            return check;
        }
        public List<Pet> FindPetById()
        {
            List<Pet> listPets= new List<Pet>();    
            try
            {
                listPet.Clear();
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                if (listPet != null)
                {
                    int id;
                    while (true)
                    {
                        listPet.ShowPet();
                        id = Validations.Instance.inputInteger("ID pet to find?", 0, 999);
                        Pet pets = listPet.GetPetById(id);
                        if (pets != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("ID pet invalid @@");
                        }
                    }
                    listPets = PetRepositoryImpl.Instance.FindPet(x =>
                    {
                        Pet pet = null;
                        if (x.Id.Equals(id))
                        {
                            pet = x;
                        }
                        return pet;
                    }, listPet);
                }
                else
                {
                    Console.WriteLine("List pet empty @@");
                }
            }
            catch
            {
                Console.WriteLine("Error at Find pet by id @@");
            }
            return listPets;
        }
        public List<Pet> FindPetByName()
        {
            List<Pet> listPets = new List<Pet>();
            listPet.Clear();
            listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
            if(listPet!=null && listPet.Count > 0)
            {
                Pet pet = null;
                listPet.ShowPet();
                string name = Validations.Instance.inputString("Name pet to find?");
                listPets = PetRepositoryImpl.Instance.FindPet(x => {
                    if (x.Name.ToLower().Contains(name.ToLower()))
                    {
                        pet = x;
                    }
                    return pet;
                }, listPet);
                listPets.ShowPet();
            }
            else
            {
                Console.WriteLine("List Pet empty @@");
            }
            return listPets;
        }
        public List<Pet> FindPetByCategory()
        {
            List<Pet> listPets = new List<Pet>();
            try
            {
                listCate.Clear();
                listPet.Clear();
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                if (listCate != null && listPet != null)
                {
                    int id;
                    while (true)
                    {
                        listCate.ShowCategory();
                        id = Validations.Instance.inputInteger("ID category?", 0, 999);
                        if (listCate.GetCategoryById(id) != null)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid category ID @@");
                        }
                    }
                    listPets = PetRepositoryImpl.Instance.FindPet(x =>
                    {
                        Pet pet = null;
                        if (x.idCate.Equals(id))
                        {
                            pet = x;
                        }
                        return pet;
                    }, listPet);
                }
                else
                {
                    if (listCate == null)
                    {
                        Console.WriteLine("List category empty @@");
                    }
                    if (listPet == null)
                    {
                        Console.WriteLine("List pet empty @@");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error at fin pet by category.");
            }
            return listPets;
        }
        public List<Pet> FindPetByVaccine()
        {
            List<Pet> listPets= new List<Pet> ();
            try
            {
                listCate.Clear();
                listPet.Clear();
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                if(listCate !=null && listPet != null)
                {
                    listPet.ShowPet();
                    int numVaccine = Validations.Instance.inputInteger("Status vaccine(0: Not injected yet, 1: Injected)",0,1);
                    Boolean vaccine=(numVaccine==0)?false:true;
                    listPets = PetRepositoryImpl.Instance.FindPet(x =>
                    {
                        Pet pet = null;
                        if (x.Vaccin.Equals(vaccine))
                        {
                            pet = x;
                        }
                        return pet;
                    }, listPet);
                }
                else
                {
                    if (listCate == null)
                    {
                        Console.WriteLine("List category is empty @@");
                    }
                    if (listPet == null)
                    {
                        Console.WriteLine("List list Pet is empty @@");
                    }
                }

            }
            catch
            {
                Console.WriteLine("Error at find pet by vaccine @@");
            }
            return listPets;
        }
        public List<Pet> FindPetByPriceLower()
        {
            List<Pet> listPets = new List<Pet>();
            try
            {
                listCate.Clear();
                listPet.Clear();
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                if (listCate != null && listPet != null)
                {
                    listPet.ShowPet();
                    float price = Validations.Instance.inputFloat("Price to find?",1,999);
                    listPets = PetRepositoryImpl.Instance.FindPet(x =>
                    {
                        Pet pet = null;
                        if (x.Price <=price)
                        {
                            pet = x;
                        }
                        return pet;
                    }, listPet);
                    listPets.ShowPet();
                }
                else
                {
                    if (listCate == null)
                    {
                        Console.WriteLine("List category is empty @@");
                    }
                    if (listPet == null)
                    {
                        Console.WriteLine("List list Pet is empty @@");
                    }
                }

            }
            catch
            {
                Console.WriteLine("Error at find pet by vaccine @@");
            }
            return listPets;
        }
        public List<Pet> FindPetByPriceUpper()
        {
            List<Pet> listPets = new List<Pet>();
            try
            {
                listCate.Clear();
                listPet.Clear();
                listPet = PetRepositoryImpl.Instance.ReadToFilePet(@"Pet.txt");
                listCate = PetRepositoryImpl.Instance.ReadToFileCategory(@"Category.txt");
                if(listCate!=null && listPet != null){
                    listPet.ShowPet();
                    float price = Validations.Instance.inputFloat("Price upper to find?", 1, 99999);
                    listPets = PetRepositoryImpl.Instance.FindPet(x =>
                    {
                        Pet pet = null;
                        if (x.Price >= price)
                        {
                            pet = x;
                        }
                        return pet;
                    }, listPet);
                    listPets.ShowPet();
                }
                else
                {
                    if (listCate == null)
                    {
                        Console.WriteLine("List category is empty @@");
                    }
                    if(listPet == null){
                        Console.WriteLine("List pet is empty");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error at find pet by price upper @@");
            }
            return listPets;
        } 
       
    }
}
