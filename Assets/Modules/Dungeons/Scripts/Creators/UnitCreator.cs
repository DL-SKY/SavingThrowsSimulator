using Modules.Dungeons.Entities;

namespace Modules.Dungeons.Creators
{
    public class UnitCreator
    {
        public UnitCreator()
        { 
            //reserved
        }

        public T Create<T>(int id) where T : Entity
        {
            //TODO: use correct type. Factory
            var u = new Unit(id, id.ToString(), new DataBase.Custom.Datas.UnitData());
            return u as T;
        }
    }
}
