using AccountManagement.model;
using AccountManagement.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.service
{
    public static class AccountExtension
    {
        private static string pathAccount = @"Account.txt";
        private static string pathCategory = @"Category.txt";
        public static void showAllCategory(this List<Category> listCategory)
        {
            if (listCategory != null)
            {
                foreach (Category category in listCategory)
                {
                    Console.WriteLine($"Id: {category.Id}, Name: {category.Name}");
                }
            }
            else
            {
                Console.WriteLine("Not Found Any Category !!");
            }
        }
        public static int getIndexAccount(this List<Account> accounts, Account account)
        {
            if (accounts != null)
            {
                int count = 0;
                foreach (Account item in accounts)
                {
                    if (item.Id.Equals(account.Id))
                    {
                        return count;
                    }
                    count++;
                }
            }
            return -1;
        }
        public static void showAllAccount(this List<Account> listAccount)
        {
            List<Category> categoryList = AccountRepository.Instance.readCategory(pathCategory);
            Category category = new Category();
            if (listAccount != null && listAccount.Count>0)
            {
                foreach (Account account in listAccount)
                {
                    category= AccountRepository.Instance.getCategoryById(categoryList, account.Idcategory);
                    Console.WriteLine($"Id: {account.Id}, Username: {account.Username}, Password: ******** , Category: {category.Name}");
                }
            }
            else if(listAccount ==null || listAccount.Count==0)
            {
                Console.WriteLine("Not Found Any Account !!");
                return;
            }
        }
        public static void showAccountWithPassword(this List<Account> listAccount, string username, string password, int id)
        {
            if (KeyService.Instance.checkKey(username, password))
            {
                List<Category> categoryList = AccountRepository.Instance.readCategory(pathCategory);
                Category category = new Category();
                if (listAccount != null)
                {
                    foreach (Account account in listAccount)
                    {
                        if (account.Id.Equals(id))
                        {
                            category = AccountRepository.Instance.getCategoryById(categoryList, account.Idcategory);
                            Console.WriteLine($"Id: {account.Id}, Username: {account.Username}, Password: {account.Password} , Category: {category.Name}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not Found Any Account !!");
                }
            }
            else
            {
                Console.WriteLine("Your action not support !!");
            }
        }
        public static void showCategory(this Category category, int count=1)
        {
            if (category != null)
            {
                Console.WriteLine($"ID: {category.Id}, Name: {category.Name}");
            }
            else
            {
                Console.WriteLine("Not Found Any Category !!");
            }
        }
        public static Boolean checkIdCategory(this int id,List<Category> category)
        {
            Boolean check = false;
            foreach (Category item in category)
            {
                if (item.Id.Equals(id))
                {
                    check = true;
                    return true;
                }
            }
            return check;
        }
        public static Boolean checkIdAccount(this int id, List<Account> accounts)
        {
            Boolean check = false;
            foreach (Account item in accounts)
            {
                if (item.Id.Equals(id))
                {
                    check = true;
                    return true;
                }
            }
            return check;
        }
        public static int generateIdAccount(this List<Account> accounts)
        {
            List<int> listId = AccountRepository.Instance.getListIdAccount(accounts);
            int count = 0;
            if (listId != null)
            {
                for (int i = 0; i < listId.Count; i++)
                {
                    if (listId[i] != count)
                    {
                        return count;
                    }
                    else if (count == listId.Count - 1)
                    {
                        count = listId.Count;
                        break;
                    }
                    count++;
                }
                return count;
            }
            else
            {
                return 0;
            }
        }
        public static int generateIdCategory(this List<Category> categories)
        {
            List<int> listId = AccountRepository.Instance.getListIdCategory(categories);
            int count = 0;
            if (listId != null)
            {
                for (int i = 0; i < listId.Count; i++)
                {
                    if (listId[i] != count)
                    {
                        return count;
                    }
                    else if (count == listId.Count - 1)
                    {
                        count = listId.Count;
                        break;
                    }
                    count++;
                }
                return count;
            }
            else
            {
                return 0;
            }
        }
    }
}
