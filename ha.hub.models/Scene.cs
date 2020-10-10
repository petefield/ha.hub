using ha.models.contracts;
using ha.sdk;
using System.Collections.Generic;
using System.Linq;

namespace ha.models
{
    public class Scene : IScene
    {

        public Scene()
        {
            Commands = new List<ICommand>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ICommand> Commands {get; set;}
    }
}
