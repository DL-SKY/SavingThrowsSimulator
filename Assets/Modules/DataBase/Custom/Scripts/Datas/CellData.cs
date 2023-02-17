using Modules.DataBase.Datas;
using System;

namespace Modules.DataBase.Custom.Datas
{
    [Serializable]
    public class VisualData
    {
        public string[] Prefabs;

        public string GetPrefab()
        {
            return Prefabs[UnityEngine.Random.Range(0, Prefabs.Length)];
        }
    }

    [Serializable]
    public class CellData : DataBaseData
    {
        public VisualData Visual;
    }
}
