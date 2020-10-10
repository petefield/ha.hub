using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ha.models.contracts;
using ha.services.contracts;
using System;
using ha.sdk;

namespace ha.services
{
    public class SceneController : ISceneController
    {
        private readonly IDeviceControllerFactory deviceControllerFactory;

        public SceneController(IDeviceControllerFactory deviceManagerFactory)
        {
            deviceControllerFactory = deviceManagerFactory;
        }

        public async Task Apply(IScene scene)
        {
            var controllers = new Dictionary<String, IDeviceController>();

            try{
                var commands = scene.Commands.OrderBy(x => x.ExecutionOrder).ToList();

                foreach (var command in commands)
                {
                    var device = command.Device;
                    var deviceType = device.DeviceType;

                    Console.WriteLine($"{device.DeviceType} : {device.Name} - {command.CommandName} ({command.Parameters})");

                    if(!controllers.ContainsKey(deviceType)){
                        Console.WriteLine($"Adding Controller for {deviceType}");
                        controllers.Add(deviceType, deviceControllerFactory.GetDeviceManager(device));
                    }

                    var deviceController = controllers[deviceType];

                    try{
                         await deviceController.ExecuteCommand(command);
                    }catch(Exception ex){
                        Console.WriteLine(ex);
                    }
                }

            }catch(Exception ex){
                Console.WriteLine(ex);
            }
        }
    }
}
