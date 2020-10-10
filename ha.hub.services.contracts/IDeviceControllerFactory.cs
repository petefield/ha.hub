using System;
using ha.models.contracts;
using ha.sdk;

namespace ha.services.contracts
{
    public interface IDeviceControllerFactory{
        IDeviceController GetDeviceManager(IDevice device);
    }
}
