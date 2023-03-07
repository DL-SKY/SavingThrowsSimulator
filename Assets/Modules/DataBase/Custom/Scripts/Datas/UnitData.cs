using Modules.DataBase.Datas;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class UnitData : DataBaseData
    {
        /// <summary>
        /// HitPoints unit
        /// </summary>
        public int MaxHitPoints;

        /// <summary>
        /// Points per turn = this is how many points are given at the beginning of the turn
        /// Cells per turn = [ SpeedPoints (ActionPoints) / GameplayData.ActionCost ]
        /// </summary>
        public int SpeedPointsPerTurn;
        public int MaxSpeedPoints;

        /// <summary>
        /// Points per turn = this is how many points are given at the beginning of the turn
        /// </summary>
        public int ActionPointsPerTurn;
        public int MaxActionPoints;



        public VisualData Visual;
    }
}
