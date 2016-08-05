using System.Reflection;
using ConsoleApplication2._0.Implements;
using ConsoleApplication2._0.Interfaces;
using Microsoft.Practices.Unity;

namespace ConsoleApplication2._0.Unity
{
    public class UnityContainerTest
    {
        public void Test()
        {
            var container = new UnityContainer();
            //直接使用如下方式，ConsoleWriter会覆盖ConsoleWarnWriter，所以需要添加KEY.
            //container.RegisterType<IWriter, ConsoleWarnWriter>();
            //container.RegisterType<IWriter, ConsoleWriter>();
            //
            container.RegisterType<IWriter, ConsoleWarnWriter>("ConsoleWarnWriter");
            container.RegisterType<IWriter, ConsoleWriter>("ConsoleWriter");
            //或者，采用如下方式：
            //container.RegisterType<ConsoleWarnWriter>();
            container.RegisterType<IWriter, ConsoleWriter>();
            container.RegisterType<ConsoleHandler>();

            var writer = container.Resolve<IWriter>("ConsoleWarnWriter");
            writer.Write("hello ");
            writer.WriteLine("world.");
            var handler = container.Resolve<ConsoleHandler>();
            handler.Handle();
        }

        public void TestAssembly()
        {
            var container = new UnityContainer();
            
        }
    }
}
