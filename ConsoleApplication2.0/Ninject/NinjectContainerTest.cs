using System;
using ConsoleApplication2._0.Implements;
using ConsoleApplication2._0.Interfaces;
using Ninject;
using Ninject.Modules;

namespace ConsoleApplication2._0.Ninject
{
    public class NinjectContainerTest
    {
        public void Test()
        {
            var kernel = new StandardKernel(new NinjectContainerModule());
            //var writer = kernel.Get<ConsoleWriter>();
            var writer = kernel.Get(typeof(ConsoleWriter)) as IWriter;
            writer.Write("hello ");
            writer.WriteLine("world.");
            var handler = kernel.Get<IHandler>();
            handler.Handle();
            var warnWriter = kernel.Get<IWriter>("WARN");
            warnWriter.Write("hello ");
            warnWriter.WriteLine("world.");
        }
    }

    public class NinjectContainerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWriter>().To<ConsoleWriter>().Named("INFO");
            Bind<IWriter>().To<ConsoleWarnWriter>().Named("WARN");
            Bind<IHandler>().To<ConsoleHandler>();
        }
    }
}
