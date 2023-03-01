using Modules.Dungeons.Creators;
using Modules.Dungeons.Entities;
using Modules.Dungeons.Generator.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Dungeons.Controllers
{
    public class Dungeon : MonoBehaviour, IDisposable
    {
        public event Action<EnumCellType[,]> OnDungeonCreate;
        public event Action<Entity> OnEntityCreate;

        //Map
        private EnumCellType[,] _dungeon;
        //...

        //Entities
        private int _lastId = 0;    //id = ++_lastId;
        private Dictionary<int, Entity> _allEntities = new Dictionary<int, Entity>();
        private Dictionary<int, Unit> _units = new Dictionary<int, Unit>();
        //...

        //Visual
        //mb implementing visual in other class?
        //...


        private void OnDestroy()
        {
            Dispose();
        }


        public void Init(object dungeonConfig, object entitiesConfig)
        {
            UnityEngine.Debug.LogError($"Dungeon.Init()");

            _lastId = 0;
            _allEntities.Clear();
            _units.Clear();

            CreateDungeon(dungeonConfig);
            CreateEntities(entitiesConfig);
        }

        public Dungeon CreateDungeon(object config)
        {
            var creator = new DungeonCreator();

            //...
            _dungeon = creator.Create(10, 10);
            //...

            OnDungeonCreate?.Invoke(_dungeon);

            return this;
        }

        public Dungeon CreateEntities(object config)
        {
            var creator = new UnitCreator();

            //...
            var unit = creator.Create<Unit>(++_lastId);
            _units.Add(unit.Id, unit);
            _allEntities.Add(unit.Id, unit);
            //...

            OnEntityCreate?.Invoke(unit);

            return this;
        }

        public void Dispose()
        {
            //...
        }
    }
}
