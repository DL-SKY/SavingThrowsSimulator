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
        public Dictionary<string, GameplayData> GameplaySettings = new Dictionary<string, GameplayData>();
        public Dictionary<string, UnitData> Units = new Dictionary<string, UnitData>();        


        public override void Init(Action completedCallback, Action<int> failedCallback)
        {
            _completedCallback = completedCallback;
            _failedCallback = failedCallback;

            LoadDataBase();
        }


        private void LoadDataBase()
        {
            LoadCells();
            LoadGameplaySettings();
            LoadUnits();

            _completedCallback?.Invoke();
        }

        private void LoadCells()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Cells"));
            FillDictionary(Cells, assets);
        }

        private void LoadGameplaySettings()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "GameplaySettings"));
            FillDictionary(GameplaySettings, assets);
        }

        private void LoadUnits()
        {
            var assets = Resources.LoadAll<TextAsset>(Path.Combine(_databasePath, "Units"));
            FillDictionary(Units, assets);
        }
    }
}
