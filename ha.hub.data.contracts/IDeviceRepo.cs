using ha.sdk;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ha.data.contracts
{
    public interface IDeviceRepo
    {
        Task<IDevice> Add(IDevice device);
        IDevice GetByName(string name);
        IEnumerable<IDevice> GetAll();
    }
}
                                                                                                                                                                                                                                                   