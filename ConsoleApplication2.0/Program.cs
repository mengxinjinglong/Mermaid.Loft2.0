using System;
using System.IO;
using ConsoleApplication2._0.NetwrokAdapter;
using ConsoleApplication2._0.Ninject;
using ConsoleApplication2._0.StructureMap;
using ConsoleApplication2._0.Unity;

namespace ConsoleApplication2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //if (!File.Exists(fileName))
                //{
                //    File.Create(fileName);
                //}
                //var domain = new NetworkAdapterDomain();
                //domain.Create();
                //domain.CheckoutAdapterType();
                Console.WriteLine("---------StructureMapContainerTest----------");
                new StructureMapContainerTest().Test();
                Console.WriteLine("---------UnityContainerTest----------");
                new UnityContainerTest().Test();
                Console.WriteLine("---------NinjectContainerTest----------");
                new NinjectContainerTest().Test();

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
            
            Console.ReadLine();
            Console.ReadLine();
            Console.ReadLine();
        }
    }
}
