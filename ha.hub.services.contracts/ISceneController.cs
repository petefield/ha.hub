using ha.models.contracts;
using System.Threading.Tasks;

namespace ha.services.contracts
{
    public interface ISceneController
    {
        Task Apply(IScene scene);
    }
}
