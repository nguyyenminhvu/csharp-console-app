using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionWithFile
{
    internal class FileService
    {
        public void deleteFile()
        {
            string paths = "";
            Console.WriteLine("Path File For Delete?");
            paths = Console.ReadLine();
            if(File.Exists(paths))
            {
                File.Delete(paths);
                Console.WriteLine(!File.Exists(paths) ? "Delete Successful" : "Fail !!");
            }
            else
            {
                Console.WriteLine("Check Path File Again.");
            }
        }
        public void showDetailFile() {
            Console.WriteLine("Path file ?");
            string path = Console.ReadLine();  
            if(File.Exists(path))
            {
                Console.WriteLine("Time Create: "+File.GetCreationTime(path).ToString());
                Console.WriteLine("Last Access Time: "+File.GetLastAccessTime(path).ToString());
            }
        }
        public void createFile()
        {
            string name = "";
            Console.WriteLine("Name File For Create?");
            name = Console.ReadLine();
            string pName= checkNameFileExtension(name);
            string paths = "";
            Console.WriteLine("Path File For Create?");
            paths = Console.ReadLine();
            string pPath=checkPathFile(paths);  
            if (Directory.Exists(paths))
            {
                File.CreateText(pPath + pName);
                if(File.Exists(pPath + pName))
                {
                    Console.WriteLine($"Create file successfully with name: {name}");
                }
               
            }
            else
            {
                Console.WriteLine("Check Path File Again.");
            }
        }
        public void rename()
        {
            string paths = "";
            Console.WriteLine("Path file for Rename?");
            paths = Console.ReadLine(); 
            if(File.Exists(paths))
            {
                try
                {
                    Console.WriteLine("New name?");
                    string nName = Console.ReadLine();
                    nName = checkNameFile(nName);
                    int index = paths.LastIndexOf(@"\");
                    string Opath = paths.Substring(0, index + 1) + nName;
                    File.Move(paths, Opath);
                    if (File.Exists(Opath))
                    {
                        Console.WriteLine("Rename Success !!");
                    }
                }
                catch
                {
                    Console.WriteLine("Rename faill !!");
                }
            }
            else
            {
                Console.WriteLine("Check path");
            }
        }

        public string checkNameFile(string s)
        {
            string rs = "";
            if(s.Trim().Length > 0)
            {
                if (s.Trim().Length > 4)
                {
                    string tmp=s.Substring(s.Trim().Length - 4);
                    if (!tmp.Equals(".txt"))
                    {
                        rs = s.Trim() + ".txt";
                    }
                    else
                    {
                        rs = s;
                    }
                }
                else
                {
                    rs = s.Trim() + ".txt";
                }
            }
            return rs;
        }
        public string checkNameFileExtension(string s)
        {
            string rs = "";
            if (s.Trim().Length > 0)
            {
                if (!s.Contains("."))
                {
                   rs = s.Trim() + ".txt";
                 }
                else
                {
                    rs = s;
                }
            }
            return rs;
        }
        public string checkPathFile(string s)
        {
            string rs = "";
            if (s.Trim().Length > 0)
            {
               string tmp = s.Substring(s.Trim().Length - 1);
               if (!tmp.Equals(@"\"))
               {
                   rs = s.Trim() + @"\";
               }
               else
               {
                   rs = s;
               }
            }
            return rs;
        }
    }
}
