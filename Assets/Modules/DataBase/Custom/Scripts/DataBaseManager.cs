using Modules.DataBase.Custom.Datas;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Modules.Custom.DataBase
{
    public class DataBaseManager : Modules.DataBase.DataBaseManager
    {
        public Dictionary<string, CellData> Cells = new Dictionary<string, CellData>();


        public override void Init(Action completedCallback, Action<int> failedCallback)
        {
            _completedCallback = completedCallback;
            _failedCallback = failedCallback;

            LoadDataBase();
        }


        private void LoadDataBase()
        {
            LoadCells();

            _completedCallback?.Invoke();

            UnityEngine.Debug.LogError($"LoadDataBase DONE");
        }

        private void LoadCells()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Cells"));
            FillDictionary(Cells, assets);
        }
    }
}
