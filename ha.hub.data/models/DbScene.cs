using ha.models.contracts;
using ha.sdk;
using System.Collections.Generic;

namespace ha.data.models
{
    class DbScene : IScene
    {
        public string Id { get; set; }

        public string Name {get; set;}
        public IEnumerable<DBCommand> Commands { get; set; }

        IEnumerable<ICommand> IScene.Commands => (IEnumerable<ICommand>)Commands;

    }
}
