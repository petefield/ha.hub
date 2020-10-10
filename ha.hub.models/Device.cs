using System.Collections.Generic;
using ha.sdk;

namespace ha.models{
    public class Device : IDevice
    {
        private Dictionary<string, string> _config;
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string DeviceType { get; set; }
        public IDictionary<string, string> Config { 
            get => _config; 
            set => _config = (Dictionary<string, string>)value; 
        }
    }
}
