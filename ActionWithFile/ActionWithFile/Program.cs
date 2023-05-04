using System;

namespace ActionWithFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileService fileService = new FileService();
            FolderService folderService = new FolderService();
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: fileService.deleteFile();     break;
                    case 2: fileService.createFile();     break;
                    case 3: fileService.rename();         break;
                    case 4: fileService.showDetailFile(); break;
                    case 5: folderService.deleteFolder(); break;
                    case 6: folderService.renameFolder(); break;
                    case 7: folderService.getListFile();  break;
                    case 8: folderService.getListFolder();break;
                    case 9: folderService.createFolder(); break;
                }
            }
        }
    }
}
