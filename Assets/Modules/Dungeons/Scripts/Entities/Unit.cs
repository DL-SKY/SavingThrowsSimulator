using Modules.DataBase.Custom.Datas;

namespace Modules.Dungeons.Entities
{
    public class Unit : Entity
    {
        private UnitData _data;

        public Unit(int id, string configId, UnitData data) : base(id, configId)
        {
            _data = data;
        }
    }
}
