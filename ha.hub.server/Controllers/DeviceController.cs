using ha.data.contracts;
using ha.models;
using ha.services.contracts;
using ha.sdk;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ha.server;

namespace ha.server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceRepo deviceRepo;
        private readonly IDeviceControllerFactory _dcf;

        public DeviceController(IDeviceRepo deviceRepo, IDeviceControllerFactory dcf)
        {
            this.deviceRepo = deviceRepo;
            _dcf = dcf;
        }

        [HttpGet]
        public IEnumerable<IDevice> GetAllDevices()
        {
            var devices = deviceRepo.GetAll();
            return devices;
        }

        [HttpPost]
        public async Task<IDevice> CreateDevice(Device d)
        {
            var result = await deviceRepo.Add(d);
            return result;
        }

        [HttpPost("{deviceName}")]
        public async Task DeviceCommand(string deviceName, ExecuteCommandRequest commandRequest )
        {
            var device = deviceRepo.GetByName(deviceName);
            var manager =  _dcf.GetDeviceManager(device);

            var command = new ha.sdk.Command{
                Device = device,
                CommandName = commandRequest.Command,
                Parameters = commandRequest.Parameters
            };

            await manager.ExecuteCommand(command);
        }
    }
}
 