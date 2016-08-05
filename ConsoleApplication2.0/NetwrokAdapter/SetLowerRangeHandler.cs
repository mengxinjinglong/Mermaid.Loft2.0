
using System;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class SetLowerRangeHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            foreach (var adapter in domain.GetNetworkAdapters())
            {
                adapter.LowerRange = RegistryUtil.GetValueListByCondition(@"SYSTEM\ControlSet001\Control\Class\{4d36e972-e325-11ce-bfc1-08002be10318}\" + adapter.Index.ToString("D4") + @"\Ndi\Interfaces", "LowerRange");
            }
        }
    }
}
