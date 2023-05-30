using System;
using System.Collections.Generic;
using System.IO;

namespace DirectoryFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
           while(true)
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine("Input your name file: ");
                string fname = Console.ReadLine();
                Console.WriteLine("Inout path: ");
                string ppp=Console.ReadLine();
                ppp = checkPathFile(ppp);
                string[] directory = Directory.GetFiles($@"{ppp}", "*", SearchOption.AllDirectories);
                List<string> listPath= new List<string>();
                if (directory.Length > 0)
                {
                    Console.WriteLine("File Path: ");
                    foreach (string dir in directory)
                    {
                        if (dir.Contains(fname)){
                            listPath.Add((string)dir);
                            Console.WriteLine(dir);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
                searchFile(listPath, fname);
            }
        }

        public static void searchFile( List<string> path,string fileName) {
            if (path != null)
            {
                Console.WriteLine("Name File: ");
                foreach (var item in path)
                {   string files = Path.GetFileName(item);
                    if (files.Contains(fileName)){
                        Console.WriteLine(files);
                    }
                }
            }
        }
        public static string checkPathFile(string s)
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
