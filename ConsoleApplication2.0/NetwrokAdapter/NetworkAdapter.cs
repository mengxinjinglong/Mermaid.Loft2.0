using System.Collections.Generic;

namespace ConsoleApplication2._0.NetwrokAdapter
{
    public class NetworkAdapter
    {
        public int Index { get; set; }
        public string Guid { get; set; }
        public string Ip { get; set; }
        public string MacAddress { get; set; }
        public bool NetEnabled { get; set; }
        public bool PhysicalAdapter { get; set; }
        public string Characteristics { get; set; }
        public string MediaSubType { get; set; }
        public string LowerRange { get; set; }
        public EnumAdapterType AdapterType { get; set; }
    }

    public enum EnumAdapterType
    {
        其他,
        无线物理网卡,
        有线物理网卡,
    }

    public class NetworkAdapterDomain
    {
        private List<NetworkAdapter> _networkAdapters;

        public NetworkAdapterDomain()
        {
            _networkAdapters = new List<NetworkAdapter>();
        }

        public List<NetworkAdapter> GetNetworkAdapters()
        {
            return _networkAdapters;
        }

        public void AddNetworkAdapter(NetworkAdapter adapter)
        {
            if(adapter==null) return;
            if (_networkAdapters == null)
            {
                _networkAdapters = new List<NetworkAdapter>();
            }
            _networkAdapters.Add(adapter);
        }

        public void Create()
        {
            new GetNetworkAdaptersHandler().Handle(this);
            new SetCharacteristicsHandler().Handle(this);
            new SetMediaSubTypeHandler().Handle(this);
            new SetLowerRangeHandler().Handle(this);
        }

        public void CheckoutAdapterType()
        {
            new CheckoutAdapterTypeHandler().Handle(this);
        }
    }
}
