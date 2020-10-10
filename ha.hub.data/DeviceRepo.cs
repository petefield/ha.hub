using ha.data.contracts;
using ha.data.models;
using ha.sdk;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ha.data
{
    public class DeviceRepo : IDeviceRepo
    {
        private readonly DatabaseContext databaseContext;

        public DeviceRepo(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private IQueryable<DbDevice> BaseQuery => databaseContext
            .Devices;

        public async Task<IDevice> Add(IDevice device)
        {
            databaseContext.Devices.Add(new DbDevice{
                Id = System.Guid.NewGuid().ToString(),
                Name = device.Id,
                Description = device.Description,
                DeviceType = device.DeviceType,
                Config = device.Config});
            await databaseContext.SaveChangesAsync();
            return device;
        }

        public IEnumerable<IDevice> GetAll() => BaseQuery.AsEnumerable();

        public IDevice GetByName(string name) => BaseQuery
            .Single(x => x.Name == name);
    }
}
