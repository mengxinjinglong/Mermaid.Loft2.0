
using System;
using ConsoleApplication2._0.Interfaces;

namespace ConsoleApplication2._0.Implements
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string content)
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.Write(content);
        }

        public void WriteLine(string content)
        {
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine(content);
        }
    }
}
