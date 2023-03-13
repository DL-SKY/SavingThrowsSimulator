using Modules.Custom.DataBase;
using Modules.Dungeons.Entities;

namespace Modules.Dungeons.Creators
{
    public class UnitCreator
    {
        private DataBaseManager _db;


        public UnitCreator(DataBaseManager db)
        {
            //reserved
            _db = db;
        }

        public T Create<T>(int id) where T : Entity
        {
            //TODO: use correct type. Factory
            var u = new Unit(id, _db.Units["Default"], _db.GameplaySettings["Default"]);
            return u as T;
        }
    }
}
