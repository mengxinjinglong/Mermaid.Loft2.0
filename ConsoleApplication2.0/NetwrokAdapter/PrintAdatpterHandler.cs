using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class PrintAdatpterHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            var fileName = AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMdd") + ".txt";
            var physicalAdapter = "";
            foreach (var adapter in domain.GetNetworkAdapters())
            {
                var content = string.Format("{0}  {1} {2} {3} {4} {5} {6} {7} {8}",
                    adapter.Characteristics,
                    adapter.Index,
                    adapter.Guid,
                    adapter.LowerRange,
                    adapter.MacAddress,
                    adapter.MediaSubType,
                    adapter.NetEnabled,
                    adapter.PhysicalAdapter,
                    adapter.AdapterType);
                Console.WriteLine(content);
                File.AppendAllText(fileName, content + Environment.NewLine);
                if (adapter.AdapterType == EnumAdapterType.无线物理网卡
                    || adapter.AdapterType == EnumAdapterType.有线物理网卡)
                {
                    physicalAdapter += content + Environment.NewLine;
                }
            }
            Console.WriteLine("==============================");
            Console.WriteLine("启用中的物理网卡：");
            Console.WriteLine(physicalAdapter);
        }
    }
}
