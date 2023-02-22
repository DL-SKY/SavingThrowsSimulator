using Modules.DataBase.Datas;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class GameplayData : DataBaseData
    {
        /// <summary>
        /// Speed points per action
        /// </summary>
        public int StepCost;
    }
}
