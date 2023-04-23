using AccountManagement.controller;
using AccountManagement.service;
using EncodeDemo;
using Quiz.service;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AccountManagement
{
    public class Program
    {
        private static AesManaged aesManaged = new AesManaged();
        private static EncodeAES encodeAES = new EncodeAES();
        private static byte[] keyAES = aesManaged.Key;
        private static byte[] IVAES = aesManaged.IV;
        static void Main(string[] args)
        {
            string username = Validations.Instance.inputString("Username?");
            string password = Validations.Instance.inputString("Password?");
            if (KeyService.Instance.checkKey(username, password))
            {
                Boolean check = true;
                while (check)
                {
                    Console.WriteLine("0. Show all account.");
                    Console.WriteLine("1. Find account by name.");
                    Console.WriteLine("2. Find account by category.");
                    Console.WriteLine("3. Add account.");
                    Console.WriteLine("4. Update account.");
                    Console.WriteLine("5. Remove account.");
                    Console.WriteLine("6. Add category.");
                    Console.WriteLine("7. Check Password");
                    Console.WriteLine("8. Generate strong password.");
                    Console.WriteLine("9. Quit");
                    int choice = Validations.Instance.inputInteger("Choice?", 0, 9);
                    switch (choice)
                    {
                        case 0: AccountController.Instance.showAllAccount(); break;
                        case 1: AccountController.Instance.findAccountByUsername(); break;
                        case 2: AccountController.Instance.findAccountByIdCategory(); break;
                        case 3: AccountController.Instance.addAccount(); break;
                        case 4: AccountController.Instance.updateAccount(); break;
                        case 5: AccountController.Instance.deleteAccount(); break;
                        case 6: AccountController.Instance.addCategory(); break;
                        case 7: AccountController.Instance.checkPassword(); break;
                        case 8: AccountController.Instance.strongPassword(); break;
                        case 9: check = false; break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Your action not support !!");
            }
            //EncodeAES encodeAES = new EncodeAES();
            //string encode=Convert.ToBase64String(encodeAES.Encrypt("Ơ}Ơ}{minhvuadasdasdasd"));
            //Console.WriteLine(encode);
            //Console.WriteLine(encodeAES.Decrypt(Convert.FromBase64String(encode)));
        }
    }
}
