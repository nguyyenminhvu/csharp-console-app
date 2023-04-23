using AccountManagement.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncodeDemo
{
    public class EncodeAES
    {
        private static AesManaged aesManaged = new AesManaged();
        private static EncodeAES encodeAES = new EncodeAES();
        private static byte[] keyAES = aesManaged.Key;
        private static byte[] IVAES = aesManaged.IV;
        //public void AESEncode()
        //{
        //    AesManaged aesManaged = new AesManaged();
        //    int choice = 0;
        //    Boolean check = true;
        //    while (check)
        //    {
        //        Console.WriteLine("1. AES Encode.");
        //        Console.WriteLine("2. Quit.");
        //        Console.WriteLine("Pick one!");
        //        string choiceTemp = Console.ReadLine();
        //        choice = Convert.ToInt32(choiceTemp);
        //        switch (choice)
        //        {
        //            case 1:
        //                Console.WriteLine("Your text?");
        //                string text= Console.ReadLine();
        //                Console.WriteLine("Before Encode: "+Encoding.UTF8.GetString(Encrypt(text, aesManaged.Key, aesManaged.IV)));
        //                byte[] temp = Encrypt(text, aesManaged.Key, aesManaged.IV);
        //                Console.WriteLine("Before Text: " + Decrypt(temp, aesManaged.Key, aesManaged.IV));
        //                break;
        //            case 2: check = false; break;
        //        }
        //    }
        //}
        // void EncryptAesManaged(string data)
        //{
        //    try
        //    {
        //        using (AesManaged aes = new AesManaged())
        //        {
        //            byte[] encrypted = Encrypt(data, aes.Key, aes.IV);
        //            Console.WriteLine($"Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
        //            string decrypted = Decrypt(encrypted, aes.Key, aes.IV);
        //            Console.WriteLine($"Decrypted data: {decrypted}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //  }
        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted = null;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(keyAES, IVAES);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            return encrypted;
        }

        public string Decrypt(byte[] cipherText)
        {
            string plaintext = null;
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(keyAES, IVAES);
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
   
}
