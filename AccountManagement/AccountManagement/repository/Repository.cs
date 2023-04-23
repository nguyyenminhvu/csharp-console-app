using AccountManagement.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.repository
{
    internal interface Repository
    {
        public List<Account> readAccount(string path);
        public List<Category> readCategory(string path);
        public void writeAccount(string path, List<Account> listAccount);
        public void writeCategory(string path, List<Category> listCategory);
        public List<Account> getAccountByCategoryId(List<Account> listAccount, int categoryId);
        public List<Account> getAccountByName(List<Account> listAccount, string name);
        public List<int> getListIdCategory(List<Category> categories);
        public List<int> getListIdAccount(List<Account> accounts);
        public Category getCategoryById(List<Category> category,int id);
        public List<Account> updateAccount(List<Account> accounts, Account account, Account accountNew);
    }
}
