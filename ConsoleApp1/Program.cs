using System.IO;
using System.Linq;
using Task_RoboCom;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System;
using System.Reflection;
using System.Reflection.Emit;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Ввод: ");
            var files = Directory.GetFiles($"{Console.ReadLine()}", "*.*", SearchOption.AllDirectories)
           .Where(s => s.EndsWith(".dll"));
            List<AddFile> rooud = new List<AddFile>();
            foreach (var t in files)
            {
                rooud.Add(new AddFile(t));
            }
            string path;
            Assembly SampleAssembly;
            foreach (AddFile t in rooud)
            {
                path = t.Name;
                SampleAssembly = Assembly.LoadFrom(path);
                foreach (var ts in SampleAssembly.GetTypes())
                {
                    Console.WriteLine(ts.Name + "  :");
                    foreach (var qq in ts.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly| BindingFlags.Public))
                    {
                         Console.WriteLine("Метод :"+qq.Name); 
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
               
            }

            Console.ReadKey();
        }
    }
}
