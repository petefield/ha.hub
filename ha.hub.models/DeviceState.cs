using ha.models.contracts;
using ha.sdk;
using System;

namespace ha.models
{
    public class Command : ICommand
    {
        public Command()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public Device Device { get; set;  }
        public string CommandName { get; set;  }
        public string Parameters { get; set; }
        public int ExecutionOrder { get ; set ; }
        IDevice ICommand.Device { 
            get => (IDevice)Device; 
            set => Device = (Device)value; 
        }
    }
}
