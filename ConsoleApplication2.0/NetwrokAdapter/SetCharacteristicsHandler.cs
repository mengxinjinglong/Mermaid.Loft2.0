
using System;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class SetCharacteristicsHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            foreach (var adapter in domain.GetNetworkAdapters())
            {
                adapter.Characteristics = RegistryUtil.GetValueListByCondition(@"SYSTEM\ControlSet001\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\" + adapter.Index.ToString("D4") , "Characteristics");
                //转换成16进制
                //int value;
                //Int32.TryParse(adapter.Characteristics, out value);
                //adapter.Characteristics = value.ToString("x");
            }
        }
    }
}
