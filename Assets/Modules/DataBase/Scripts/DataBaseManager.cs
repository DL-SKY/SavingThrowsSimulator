using Modules.DataBase.Datas;
using Modules.DataBase.Properties;
using Modules.DataBase.Providers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.DataBase
{
    public abstract class DataBaseManager : MonoBehaviour
    {
        protected Action _completedCallback;
        protected Action<int> _failedCallback;

        [SerializeField] protected string _databasePath;

        [Header("Providers")]
        [SerializeField] protected PropertyProvider _propertyProvider;

        public abstract void Init(Action completedCallback, Action<int> failedCallback);

        protected void FillDictionary<T>(Dictionary<string, T> dic, TextAsset[] assets) where T : DataBaseData
        {
            foreach (var asset in assets)
            {
                var value = DeserializeFromAsset<T>(asset);
                dic.Add(value.Id, value);
            }
        }

        protected T DeserializeFromAsset<T>(TextAsset asset) where T : DataBaseData
        {
            T value = JsonUtility.FromJson<T>(asset.text);
            value.Id = asset.name;
            return value;
        }

        protected void FillProperties(Property[] properties)
        {
            foreach (var property in properties)
                property.Data = _propertyProvider.GetPropertyData(property.Type, property.SerializedData);
        }




        //private void LoadStats()
        //{
        //    Stats = DeserializeFromAsset<Stats>(_stats);
        //}

        //private void LoadRaces()
        //{
        //    FillDictionary<Race>(Races, _races);
        //    foreach (var race in Races)
        //        FillProperties(race.Value.properties);
        //}




        //== test hardcode profile/state= =
        //var debugProfile = new State.State();
        //debugProfile.playerId = Random.Range(0, 999999);
        //debugProfile.characters = new System.Collections.Generic.List<DnD.State.Character>();
        //var character = new Character();
        //character.name = "Name";
        //character.experience = 0;
        //character.raceId = "Race";
        //character.subRaceId = "SubRace";
        //character.classes = new System.Collections.Generic.List<Assets.Scripts.Modules.DnD.CustomTypes.CharacterClassData>();
        //character.classes.Add(new Assets.Scripts.Modules.DnD.CustomTypes.CharacterClassData() { classId = "Class", level = 1});
        //character.backgroundId = "Background";
        //character.staticCalculatedData = new System.Collections.Generic.List<StaticCalculatedCharacterData>();
        //var data = new StaticCalculatedCharacterData();
        //data.type = EnumCharacterData.Class;
        //data.dbDataId = character.classes[0].classId;
        //data.stats = new System.Collections.Generic.List<CharacterStatsData>();
        //data.stats.Add(new CharacterStatsData() { stats = DnD.Enums.EnumStats.Strength, value = -1 });
        //data.savingThrows = new System.Collections.Generic.List<DnD.Enums.EnumStats>();
        //data.savingThrows.Add(DnD.Enums.EnumStats.Charisma);
        //data.skills = new System.Collections.Generic.List<DnD.Enums.EnumSkills>();
        //data.skills.Add(DnD.Enums.EnumSkills.History);
        //character.staticCalculatedData.Add(data);
        //debugProfile.characters.Add(character);
        //UnityEngine.Debug.LogError($"debugProfile: {JsonUtility.ToJson(debugProfile)}");        
    }
}
