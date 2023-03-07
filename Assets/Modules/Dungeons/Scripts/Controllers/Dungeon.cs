using Modules.Custom.DataBase;
using Modules.Dungeons.Creators;
using Modules.Dungeons.Entities;
using Modules.Dungeons.Generator.Enums;
using Modules.StarterKIT.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Dungeons.Controllers
{
    public class Dungeon : MonoBehaviour, IDisposable
    {
        [SerializeField] private float _angle;


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


        private void Update()
        {
            foreach (var entity in _allEntities.Values)
            {
                //TODO: debug
                if (Input.GetKeyDown(KeyCode.A))
                    entity.StartMove(GetPos(_angle, Vector2.left));
                if (Input.GetKeyDown(KeyCode.D))
                    entity.StartMove(GetPos(_angle, Vector2.right));
                if (Input.GetKeyDown(KeyCode.W))
                    entity.StartMove(GetPos(_angle, Vector2.up));
                if (Input.GetKeyDown(KeyCode.S))
                    entity.StartMove(GetPos(_angle, Vector2.down));

                Vector2 GetPos(float angle, Vector2 vector)
                {
                    var rad = angle * Mathf.PI / 180.0f;
                    var x = vector.x * Mathf.Cos(rad) - vector.y * Mathf.Sin(rad);
                    var y = vector.y * Mathf.Cos(rad) + vector.x * Mathf.Sin(rad);
                    return new Vector2(x, y);
                }

                entity.Update(Time.deltaTime);               
            }
        }

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
            var creator = new UnitCreator(ComponentLocator.Resolve<DataBaseManager>());

            //...
            var unit = creator.Create<Unit>(++_lastId);
            _units.Add(unit.Id, unit);
            _allEntities.Add(unit.Id, unit);
            //...

            OnEntityCreate?.Invoke(unit);

            return this;
        }

        public Unit GetUnit(int id)
        {
            if (_units.ContainsKey(id))
                return _units[id];

            return null;
        }

        public void Dispose()
        {
            //...
        }
    }
}
