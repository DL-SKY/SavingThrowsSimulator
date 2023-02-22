using Modules.Dungeons.Entities;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Dungeons.Controllers
{
    public class Dungeon : MonoBehaviour, IDisposable
    {
        //Entities
        private int _lastId = 0;
        private Dictionary<int, Entity> _allEntities = new Dictionary<int, Entity>();
        private Dictionary<int, Unit> _units = new Dictionary<int, Unit>();
        //...


        public void Init()
        {
            UnityEngine.Debug.LogError($"Dungeon.Init()");

            _lastId = 0;
            _allEntities.Clear();
            _units.Clear();
        }

        public void Dispose()
        {
            //...
        }
    }
}
