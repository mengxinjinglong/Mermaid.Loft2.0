using System;
using System.Management;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class GetNetworkAdaptersHandler
    {
        public void Handle(NetworkAdapterDomain domain)
        {
            if (Environment.OSVersion.Version.Major == 5)
            {
                HandleForXp(domain);
            }
            else
            {
                HandleForWin7(domain);
            }
        }

        private void HandleForWin7(NetworkAdapterDomain domain)
        {
            using (ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_NetworkAdapter"))
            {
                foreach (var o in searcher.Get())
                {
                    var queryObj = (ManagementObject)o;
                    var adapter = new NetworkAdapter();
                    if (queryObj["Index"] != null)
                        adapter.Index = Convert.ToInt32(queryObj["Index"].ToString());
                    if (queryObj["Guid"] != null)
                        adapter.Guid = queryObj["Guid"].ToString();
                    if (queryObj["MacAddress"] != null)
                        adapter.MacAddress = queryObj["MacAddress"].ToString();
                    if (queryObj["NetEnabled"] != null)
                        adapter.NetEnabled = Convert.ToBoolean(queryObj["NetEnabled"].ToString());
                    if (queryObj["PhysicalAdapter"] != null)
                        adapter.PhysicalAdapter = Convert.ToBoolean(queryObj["PhysicalAdapter"].ToString());
                    domain.AddNetworkAdapter(adapter);
                }
            }
        }

        private void HandleForXp(NetworkAdapterDomain domain)
        {
            using (ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_NetworkAdapterConfiguration"))
            {
                foreach (var o in searcher.Get())
                {
                    var queryObj = (ManagementObject)o;
                    var adapter = new NetworkAdapter();
                    if (queryObj["Index"] != null)
                        adapter.Index = Convert.ToInt32(queryObj["Index"].ToString());
                    if (queryObj["SettingID"] != null)
                        adapter.Guid = queryObj["SettingID"].ToString();
                    if (queryObj["MacAddress"] != null)
                        adapter.MacAddress = queryObj["MacAddress"].ToString();
                    if (queryObj["IPEnabled"] != null)
                        adapter.NetEnabled = Convert.ToBoolean(queryObj["IPEnabled"].ToString());
                    adapter.PhysicalAdapter = true;
                    domain.AddNetworkAdapter(adapter);
                }
            }
        }
    }
}
