using System;
using ConsoleApplication2._0.Interfaces;

namespace ConsoleApplication2._0.Implements
{
    public class ConsoleHandler : IHandler
    {
        private IWriter _writer;
        public ConsoleHandler(IWriter writer)
        {
            _writer = writer;
        }

        public void Handle()
        {
            _writer.Write("hello ");
            _writer.WriteLine("world.");
        }
    }
}
