using Modules.Dungeons.Entities;
using Modules.Dungeons.Viewer;
using UnityEngine;

namespace Modules.Dungeons.Creators
{
    public static class EntityViewFactory
    {
        public static EntityView Create(Entity entity)
        {
            return entity switch
            {
                Unit unit => CreateUnitView(unit),
                _ => null   //TODO: exception
            };
        }

        private static UnitView CreateUnitView(Unit unit)
        {
            var prefab = Resources.Load<UnitView>("TmpUnit");
            var view = GameObject.Instantiate<UnitView>(prefab);
            view.Init(unit);

            return view;
        }
    }
}
