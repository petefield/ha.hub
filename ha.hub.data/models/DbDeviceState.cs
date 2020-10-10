using System;
using ha.models.contracts;
using ha.sdk;

namespace ha.data.models
{
    class DBCommand : ICommand
    {
        public DBCommand()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DbDevice Device { get; set; }
        public string CommandName { get; set; }
        public string Parameters { get; set; }
        public int ExecutionOrder { get; set; }

        IDevice ICommand.Device { get => Device; set => Device = (DbDevice)value; }
    }
}
