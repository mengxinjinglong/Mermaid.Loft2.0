

using System;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class SetMediaSubTypeHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            foreach (var adapter in domain.GetNetworkAdapters())
            {
                adapter.MediaSubType = RegistryUtil.GetValueListByCondition(@"SYSTEM\CurrentControlSet\Control\Network\{4D36E972-E325-11CE-BFC1-08002BE10318}\"+adapter.Guid+@"\Connection", "MediaSubType");
            }
        }
    }
}
