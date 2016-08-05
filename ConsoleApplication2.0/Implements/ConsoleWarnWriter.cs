
using System;
using ConsoleApplication2._0.Interfaces;

namespace ConsoleApplication2._0.Implements
{
    public class ConsoleWarnWriter : IWriter
    {
        public void Write(string content)
        {
            Console.ForegroundColor= ConsoleColor.DarkGreen;
            Console.Write(content);
        }

        public void WriteLine(string content)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(content);
        }
    }
}
