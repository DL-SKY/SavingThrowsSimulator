using Modules.DataBase.Custom.Datas;

namespace Modules.Dungeons.Entities
{
    public class Unit : Entity  //Добавить интерфейс ~IActivity который совершает действия, тратит очки и пр.
    {
        private UnitData _data;

        //IMoveable
        protected override int SpeedPointsPerTurn => _data.SpeedPointsPerTurn;
        protected override int MaxSpeedPoints => _data.MaxSpeedPoints;

        //IDamageable
        public override int MaxHitPoints => _data.MaxHitPoints;


        public Unit(int id, UnitData data) : base(id, data.Id)
        {
            _data = data;

            CurrentHitPoints = MaxHitPoints;
        }


        public override void RefreshTurn()
        {
            base.RefreshTurn();

            //ActionPoints
            //TODO: ...
        }
    }
}
