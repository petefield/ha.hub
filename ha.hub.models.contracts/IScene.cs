using System.Collections.Generic;
using ha.sdk;

namespace ha.models.contracts
{
    public interface IScene
    {
        string Id { get; set; }

        string Name { get; set; }

        IEnumerable<ICommand> Commands { get;  }

    }
}
