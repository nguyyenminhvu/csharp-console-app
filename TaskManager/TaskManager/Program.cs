using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace TaskManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
               while (true)
                {
                Dictionary<BigInteger, String> processMap = new Dictionary<BigInteger, String>();
                Process[] processesApp = Process.GetProcesses();
                foreach (Process item in processesApp)
                {
                    Console.WriteLine($"ID: {item.Id}, Name: {item.ProcessName}");
                    processMap.Add(item.Id, item.ProcessName);
                }
                Console.WriteLine("Press D to end task proccess.");
                if (Console.Read() == 'd')
                {
                    Console.WriteLine("ID Task?");
                    Console.ReadLine();
                    int d = Convert.ToInt32(Console.ReadLine());
                    Process.GetProcessById(d).Kill();
                    Console.WriteLine("Deleted");
                }
            }
        }
    }
}
