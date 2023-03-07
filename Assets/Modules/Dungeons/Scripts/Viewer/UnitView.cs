using Modules.Dungeons.Entities;
using UnityEngine;

namespace Modules.Dungeons.Viewer
{
    public class UnitView : EntityView
    {

        protected override void CustomInit(Entity _entity)
        {

        }


        public override void Dispose()
        {
            
        }
               

        protected override void CustomSubscribe()
        {

        }

        protected override void CustomUnsubscribe()
        {

        }

        protected override void OnHitPointsChangeHandler(int id, int currentHitPoints, int maxHitPoints)
        {

        }

        protected override void OnPositionChangeHandler(int id, Vector2 position)
        {
            transform.position = new Vector3(position.x, transform.position.y, position.y);
        }

        protected override void OnDyingHandler(int id)
        {

        }
    }
}
