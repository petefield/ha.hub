using ha.models.contracts;
using System.Collections.Generic;

namespace ha.data.contracts
{
    public interface ISceneRepo
    {
        IScene GetSceneByName(string name);
        IEnumerable<IScene> GetAll();
    }
}
                                                                                                                                                                                                                                                   