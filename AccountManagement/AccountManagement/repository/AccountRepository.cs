using AccountManagement.model;
using AccountManagement.service;
using EncodeDemo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.ComponentModel;

namespace AccountManagement.repository
{
    public class AccountRepository:Repository
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        private static AesManaged aesManaged = new AesManaged();
        private static EncodeAES encodeAES = new EncodeAES();
        private static byte[] keyAES = aesManaged.Key;
        private static byte[] IVAES = aesManaged.IV;
        private static AccountRepository instance;
        public static AccountRepository Instance { get { if (instance == null) { instance = new AccountRepository(); }return instance; } private set => instance = value; }
        public List<Account> getAccountByCategoryId(List<Account> listAccount, int categoryId)
        {
          return listAccount.Where(x=> x.Idcategory==categoryId).ToList();
        }
        public Account getAccountById(List<Account> listAccount, int categoryId)
        {
            Account accounts = listAccount.Where(x => x.Idcategory == categoryId).Single();
            return (accounts != null) ? accounts : null;
        }
        public List<Account> getAccountByName(List<Account> listAccount, string name)
        {
            List<Account> accounts = listAccount.Where(x => x.Username.ToLower().Contains(name.ToLower())).ToList();
            return (accounts!=null)?accounts:null;
        }
        public Category getCategoryById(List<Category> category, int id)
        {
            Category category2 = null;
            foreach (Category item in category)
            {
                if (item.Id.Equals(id))
                {
                    category2 = new Category();
                    category2 = item;
                    return category2;   
                }
            }
            return null;
        }
        public List<int> getListIdAccount(List<Account> accounts)
        {
            if (accounts != null)
            {
                return accounts.Select(x => x.Id).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<int> getListIdCategory(List<Category> categories)
        {
            if (categories != null)
            {
                return categories.Select(x => x.Id).ToList();
            }
            else
            {
                return null;
            }
        }
        public List<Account> readAccount(string path)
        {
            List<Account> listAccount= new List<Account>();
            string json=File.ReadAllText(path);
            listAccount=JsonConvert.DeserializeObject<List<Account>>(json); 
            return listAccount;
        }
        public List<Category> readCategory(string path)
        {
            List<Category> categories = new List<Category>();
            string json=File.ReadAllText(path);
            categories= JsonConvert.DeserializeObject<List<Category>>(json);
            return categories;
        }
        public List<Account> updateAccount(List<Account> accounts, Account account, Account accountNew)
        {
            Boolean check = false;
            int index = accounts.getIndexAccount(account);
            if (index > 0)
            {
                accounts[index].Username = accountNew.Username;
                accounts[index].Password = accountNew.Password;
                accounts[index].Idcategory = accountNew.Idcategory;
            }
            return accounts;
        }
        public void writeAccount(string path, List<Account> listAccount)
        {
           string json=JsonConvert.SerializeObject(listAccount);
           File.WriteAllText(path, json);
           Console.WriteLine("Save Account success !!");
        }
        public void writeCategory(string path, List<Category> listCategory)
        {
            string json= JsonConvert.SerializeObject(listCategory); 
            File.WriteAllText(path, json);
            Console.WriteLine("Save Category Success !!");
        }
    }
}
