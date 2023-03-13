using Modules.DataBase.Custom.Datas;

namespace Modules.Dungeons.Entities
{
    public class Unit : Entity
    {
        private UnitData _data;
        private GameplayData _gameplayData;

        //IMoveable
        protected override int SpeedPointsPerTurn => _data.SpeedPointsPerTurn;
        public override int MaxSpeedPoints => _data.MaxSpeedPoints;
        public override int StepCost => _gameplayData.StepCost;

        //IDamageable
        public override int MaxHitPoints => _data.MaxHitPoints;

        //IActive
        protected override int ActionPointsPerTurn => _data.ActionPointsPerTurn;
        public override int MaxActionPoints => _data.MaxActionPoints;


        public Unit(int id, UnitData data, GameplayData gameplayData) : base(id, data.Id)
        {
            _data = data;
            _gameplayData = gameplayData;

            CurrentSpeedPoints = MaxSpeedPoints;
            CurrentHitPoints = MaxHitPoints;
            CurrentActionPoints = MaxActionPoints;
        }


        //public override void RefreshTurn()
        //{
        //    base.RefreshTurn();            
        //}
    }
}
