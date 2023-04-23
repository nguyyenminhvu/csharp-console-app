using AccountManagement.model;
using AccountManagement.repository;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.service
{
    public class AccountService
    {
        private static List<Account> listAccount = new List<Account>();
        private static List<Category> listCategory = new List<Category>();
        private static Random random = new Random();
        private static string pathAccount = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\AccountManagement\\AccountManagement\\Account.txt";
        private static string pathCategory = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\AccountManagement\\AccountManagement\\Category.txt";
        public AccountService() { }
        public void addAccount()
        {
            listAccount.Clear();
            listCategory.Clear();   
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listCategory=AccountRepository.Instance.readCategory(pathCategory);
            if(listAccount == null)
            {
                listAccount = new List<Account>();  
            }
            if(listCategory == null)
            {
                addCategory();
                listCategory.Clear();
                listCategory = AccountRepository.Instance.readCategory(pathCategory);
            }
            string username = Validations.Instance.inputString("username to add?");
            string password = Validations.Instance.inputString("password to add");
            int id = listAccount.generateIdAccount();
            listCategory.showAllCategory();
            int idCate = 0;
            while (true)
            {
                idCate = Validations.Instance.inputInteger("Id Category?", 0, 999);
                if (idCate.checkIdCategory(listCategory))
                {
                    break;
                }
            }
            Account account = new Account(id, username, password, idCate);
            listAccount.Add(account);
            AccountRepository.Instance.writeAccount(pathAccount, listAccount);
        }
        public void addCategory()
        {
            listCategory.Clear();
            listCategory = AccountRepository.Instance.readCategory(pathCategory);
            if (listCategory == null)
            {
                listCategory = new List<Category>();    
            }
            string name=Validations.Instance.inputString("Name of Category?");
            int id = listCategory.generateIdCategory();
            Category category = new Category(id, name);
            listCategory.Add(category);
            AccountRepository.Instance.writeCategory(pathCategory, listCategory);
        }
        public List<Account> findAccountByIdCategory(int id)
        {
            listAccount.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            List<Account> accounts = new List<Account>();
            if (listAccount != null)
            {
              
                accounts = AccountRepository.Instance.getAccountByCategoryId(listAccount, id);
            }
            else if(accounts==null || accounts.Count==0)
            {
                Console.WriteLine($"Not found any category with ID {id} !!");
            } else if (listAccount == null)
            {
                Console.WriteLine("The List Account Empty!!");
            }
            return accounts;
        }
        public List<Account> findAccountByUsername(string name)
        {
            List<Account> accounts = new List<Account>(); 
            listAccount.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            if (listAccount != null)
            {
                accounts=AccountRepository.Instance.getAccountByName(listAccount, name);
            }
            if(accounts ==null || accounts.Count == 0)
            {
                Console.WriteLine($"Not found any account with name {name} !!");
            }
            return accounts;
        }
        public void updateAccount()
        {
            listAccount.Clear();
            listCategory.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listCategory = AccountRepository.Instance.readCategory(pathCategory);
            listAccount.showAllAccount();
            int id = 0;
            while (true)
            {
                id = Validations.Instance.inputInteger("Id Account update? ", 0, 999);
                if (id.checkIdAccount(listAccount))
                {
                    break;
                }
            }
            string newUsername = Validations.Instance.inputString("New Username?");
            string newPassword = Validations.Instance.inputString("New Password");
            listCategory.showAllCategory();
            int idCate = 0;
            while (true)
            {
                idCate = Validations.Instance.inputInteger("Id Category?", 0, 999);
                if (idCate.checkIdCategory(listCategory))
                {
                    break;
                }
            }
            Account account = AccountRepository.Instance.getAccountById(listAccount,id);
            Account newAccount = new Account(id, newUsername, newPassword, idCate);
            listAccount=AccountRepository.Instance.updateAccount(listAccount,account,newAccount);   
            AccountRepository.Instance.writeAccount(pathAccount, listAccount);
            Console.WriteLine("Update successfull !!");
        }
        public void removeAccount()
        {
            listAccount.Clear();
            listCategory.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listCategory = AccountRepository.Instance.readCategory(pathCategory);
            int id = 0;
            while (true)
            {
                listAccount.showAllAccount();
                id = Validations.Instance.inputInteger("Id Account remove? ", 0, 999);
                if (id.checkIdAccount(listAccount))
                {
                    break;
                }
            }
            string newUsername = Validations.Instance.inputString("username?");
            string newPassword = Validations.Instance.inputString("password");
            if (KeyService.Instance.checkKey(newUsername, newPassword))
            {
                listAccount.RemoveAt(id);
                AccountRepository.Instance.writeAccount(pathAccount,listAccount);
                Console.WriteLine("Remove successfull !!");
            }
        }
        public string generatorPassword()
        {
            string name = Validations.Instance.inputString("Your name please?");
            string[] arrayName = name.Split(" ");
            int counts = 8;
            if (arrayName.Length ==1)
            {
                name= arrayName[0]; 
            }else if(arrayName.Length == 2)
            {
                name = arrayName[1];
            }else if (arrayName.Length == 3)
            {
                name = arrayName[2];
            }
            if (name.Length > 8)
            {
                counts= name.Length+4;
            }
            string specialChar = randomInt("!@#$%^&*",(counts - name.Length)/2);
            string numChar = randomInt("1234567890",counts-(specialChar.Length+name.Length));
            string rs = "";
            int ran = random.Next(0, 2);
            switch (ran)
            {
                case 0: rs=name+specialChar+numChar; break;
                case 1: rs=name+numChar+specialChar; break;
                case 2: rs=numChar+name+specialChar; break; 
            }
            return rs;
        }
        public string randomInt(string str, int length)
        {
            string rs = "";
            for (int i = 0; i < length; i++)
            {
                rs += str[random.Next(0, str.Length - 1)];
            }
            return rs;
        }
    }

}
