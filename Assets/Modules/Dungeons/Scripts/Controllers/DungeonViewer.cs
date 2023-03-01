using Modules.Dungeons.Creators;
using Modules.Dungeons.Entities;
using Modules.Dungeons.Generator.Enums;
using Modules.Dungeons.Viewer;
using Modules.StarterKIT.Services;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.Dungeons.Controllers
{
    public class DungeonViewer : MonoBehaviour, IDisposable
    {
        private Dungeon _dungeon;

        private Dictionary<int, EntityView> _allViews = new Dictionary<int, EntityView>();


        private void Start()
        {
            _dungeon = ComponentLocator.Resolve<Dungeon>();

            Subscribe();
        }

        private void OnDestroy()
        {
            Dispose();
        }


        public void Dispose()
        {
            Unsubscribe();
        }


        private void Subscribe()
        {
            _dungeon.OnDungeonCreate += OnDungeonCreateHandler;
            _dungeon.OnEntityCreate += OnEntityCreateHandler;
        }

        private void Unsubscribe()
        {
            _dungeon.OnDungeonCreate -= OnDungeonCreateHandler;
            _dungeon.OnEntityCreate -= OnEntityCreateHandler;
        }

        private void OnDungeonCreateHandler(EnumCellType[,] map)
        { 
            //...
        }

        private void OnEntityCreateHandler(Entity entity)
        {
            var view = EntityViewFactory.Create(entity);
            //...

            _allViews.Add(entity.Id, view);
        }
    }
}
