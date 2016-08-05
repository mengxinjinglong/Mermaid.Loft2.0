using ConsoleApplication2._0.Implements;
using ConsoleApplication2._0.Interfaces;
using StructureMap;

namespace ConsoleApplication2._0.StructureMap
{
    public class StructureMapContainerTest
    {
        public void Test()
        {
            ObjectFactory.Initialize(container =>
            {
                container.For<IWriter>().Use<ConsoleWriter>().Named("INFO");
                container.For<IWriter>().Use<ConsoleWarnWriter>().Named("WARN");
                container.For<ConsoleHandler>();
                container.Scan((scaner) =>
                {
                    scaner.Assembly("ConsoleApplication2.0");
                });
            });

            var writer = ObjectFactory.GetNamedInstance<IWriter>("INFO");
            writer.Write("hello ");
            writer.WriteLine("world!");
            var handler = ObjectFactory.GetInstance<ConsoleHandler>();
            handler.Handle();
        }
    }
}
