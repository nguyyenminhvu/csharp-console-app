using AccountManagement.model;
using AccountManagement.repository;
using AccountManagement.service;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.controller
{
    public class AccountController
    {
        private static List<Account> listAccount = new List<Account>();
        private static List<Category> listCategory = new List<Category>();
        private static string pathAccount = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\AccountManagement\\AccountManagement\\Account.txt";
        private static string pathCategory = "C:\\Users\\ACER\\Desktop\\General\\.NET Console App Lamboro\\AccountManagement\\AccountManagement\\Category.txt";
        private static AccountService accountService = new AccountService();

        private static AccountController instance;
        public AccountController() { }
        public static AccountController Instance { get { if (instance == null) { instance = new AccountController(); }return instance; } private set => instance = value; }
        public void showAllAccount()
        {
            listAccount.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listAccount.showAllAccount();
        }
        public void addAccount()
        {
            accountService.addAccount();
        }
        public void addCategory()
        {
            accountService.addCategory();
        }
        public void updateCategory()
        {
            accountService.updateAccount();
        }
        public void findAccountByIdCategory()
        {
            listAccount.Clear();
            listCategory.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listCategory=AccountRepository.Instance.readCategory(pathCategory);
            int id = 0;
            while (true)
            {
                listCategory.showAllCategory();
                id = Validations.Instance.inputInteger("Id category?", 0, 999);
                if (AccountExtension.checkIdCategory(id, listCategory))
                {
                    break;
                }
            }
            accountService.findAccountByIdCategory(id).showAllAccount();
        }
        public void findAccountByUsername() {
            string username = Validations.Instance.inputString("username?");
            accountService.findAccountByUsername(username).showAllAccount();
        }
        public void checkPassword()
        {
            listAccount.Clear();
            listCategory.Clear();
            listAccount = AccountRepository.Instance.readAccount(pathAccount);
            listCategory = AccountRepository.Instance.readCategory(pathCategory);
            listAccount.showAllAccount();
            int id = 0;
            while (true)
            {
                id = Validations.Instance.inputInteger("Id Account ? ", 0, 999);
                if (id.checkIdAccount(listAccount))
                {
                    break;
                }
            }
            string username = Validations.Instance.inputString("username?");
            string password = Validations.Instance.inputString("password?");
            listAccount.showAccountWithPassword(username, password, id);
        }
        public void updateAccount()
        {
            accountService.updateAccount();
        }
        public void deleteAccount()
        {
            accountService.removeAccount();
        }
        public void strongPassword()
        {
         string password= accountService.generatorPassword();
            if (password != null)
            {
                Console.WriteLine("Strong password: " + password);
            }
        }
    }
}
