using ha.data.contracts;
using ha.data.models;
using ha.models.contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ha.data
{
    public class SceneRepo : ISceneRepo
    {
        private readonly DatabaseContext databaseContext;

        public SceneRepo(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        private IQueryable<DbScene> BaseQuery => databaseContext
            .Scenes
            .Include(x => x.Commands)
            .ThenInclude(x => x.Device);

        public IEnumerable<IScene> GetAll() => BaseQuery.AsEnumerable();

        public IScene GetSceneByName(string name) => BaseQuery
            .Single(x => x.Name == name);
    }
}
