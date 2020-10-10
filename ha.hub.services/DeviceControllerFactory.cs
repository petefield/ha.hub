using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ha.models.contracts;
using ha.sdk;
using ha.services.contracts;


namespace ha.services
{
    public class DeviceControllerFactory : IDeviceControllerFactory
    {
        Dictionary<string, Type> _controllerTypeLookup = new Dictionary<string, Type>();
        private readonly IServiceProvider serviceProvider;

        public DeviceControllerFactory(IServiceProvider serviceProvider,  Dictionary<string, Type> controllerTypeLookup )
        {
            this.serviceProvider = serviceProvider;
            _controllerTypeLookup = controllerTypeLookup;
        }

        
        public IDeviceController GetDeviceManager(IDevice device)
        {
            var deviceControllerType = _controllerTypeLookup[device.DeviceType];

            var deviceContollerInstance = serviceProvider.GetService(deviceControllerType) as IDeviceController;

            return deviceContollerInstance;
        }
    }
}
