using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ActionWithFile
{
    internal class FolderService:FileService
    {
        public void createFolder()
        {
            Console.WriteLine("Name folder for create?");
            string fName=Console.ReadLine();
            Console.WriteLine("Path?");
            string paths=Console.ReadLine();
            paths=checkPathFile(paths); 
            if(Directory.Exists(paths)){
                string tmp = paths + fName;
                DirectoryInfo nPath =new DirectoryInfo(tmp);
                nPath.Create();
                if (Directory.Exists(tmp))
                {
                    Console.WriteLine("Create Success");
                }
            }
        }

        public void deleteFolder()
        {
            Console.WriteLine("Path folder to delete?");
            string paths=Console.ReadLine();
            if (Directory.Exists(paths))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(paths);
                string[] listFileName = Directory.GetFiles(paths);
                if (listFileName.Length >0) {
                    deleteFilesInFolder(listFileName);
                }
                    directoryInfo.Delete();
                    if (!Directory.Exists(paths))
                    {
                        Console.WriteLine("Delete Success !!");
                   }              
            }
        }
        public void renameFolder()
        {
            Console.WriteLine("Path folder for rename?");
            string paths=Console.ReadLine();
            if (Directory.Exists(paths))
            {
                Console.WriteLine("New name?");
                string nName = Console.ReadLine();
                int  index=paths.LastIndexOf(@"\");  
                string tmp =paths.Substring(0, index);
                tmp=checkPathFile(tmp); 
                string newPP = tmp + nName;
                Directory.Move(paths, newPP);
                if (Directory.Exists(newPP))
                {
                    Console.WriteLine("Rename success !!");
                }

            }
        }
        public void getListFile()
        {
            Console.WriteLine("Path folder for get all file?");
            string paths=Console.ReadLine();    
            if(Directory.Exists(paths))
            {
                string[] fileList= Directory.GetFiles(paths);
                foreach (string pathss in fileList)
                {
                   string tmp =Path.GetFileName(pathss);
                    Console.WriteLine($"{tmp}");
                        
                }
            }
        }
        public void getListFolder()
        {
            Console.WriteLine("Path folder for get all?");
            string paths = Console.ReadLine();
            if (Directory.Exists(paths))
            {
                listFolder(paths);
            }
        }
        public void listFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                return;
            }
            var listSubfolder = new DirectoryInfo(path).GetDirectories();
            foreach (DirectoryInfo item in listSubfolder)
            {
                Console.WriteLine($"{item}");
                string tmp= item.FullName.ToString();
                listFolder(tmp);
            }
        }
        public void deleteFilesInFolder(string[] listNameFile)
        {
            foreach (var item in listNameFile)
            {
                File.Delete(item);
                Console.WriteLine(!File.Exists(item) ? "Delete File Successful" : "Fail !!");
            }
        }
    }
}
