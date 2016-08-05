
using System;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class CheckoutAdapterTypeHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            foreach (var adapter in domain.GetNetworkAdapters())
            {
                if (adapter.NetEnabled 
                    && adapter.PhysicalAdapter
                    && CheckoutPhysicalAdapter(adapter.Characteristics))
                {
                    if (adapter.MediaSubType == "2"
                        && adapter.LowerRange != null
                        && (adapter.LowerRange.ToLower().Contains("wifi")
                            || adapter.LowerRange.Contains("wlan")))
                    {
                        adapter.AdapterType = EnumAdapterType.无线物理网卡;
                    }
                    else
                    {
                        adapter.AdapterType = EnumAdapterType.有线物理网卡;
                    }
                }
            }
        }

        private bool CheckoutPhysicalAdapter(string characteristics)
        {
            int value;
            Int32.TryParse(characteristics, out value);
            return (value&4)==4;
        }
    }
}
