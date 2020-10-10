using ha.data.contracts;
using ha.models.contracts;
using ha.services.contracts;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ha.server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SceneController : ControllerBase
    {
        private readonly ISceneRepo sceneRepo;
        private readonly ISceneController sceneController;

        public SceneController(ISceneRepo sceneRepo, ISceneController sceneController)
        {
            this.sceneRepo = sceneRepo;
            this.sceneController = sceneController;
        }

        [HttpPost]
        public void Apply(string sceneName)
        {
            var scene = sceneRepo.GetSceneByName(sceneName);
            sceneController.Apply(scene);
        }

        [HttpGet]
        public IEnumerable<IScene> Scenes()
        {
            var scenes = sceneRepo.GetAll();
            return scenes;
        }
    }
}
