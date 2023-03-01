using Modules.Dungeons.Entities;
using System;
using UnityEngine;

namespace Modules.Dungeons.Viewer
{
    public abstract class EntityView : MonoBehaviour, IDisposable
    {
        protected Entity _entity;


        public abstract void Dispose();

        public void Init(Entity entity)
        {
            _entity = entity;
            CustomInit(_entity);

            Subscribe();
        }


        protected abstract void CustomInit(Entity _entity);
        protected abstract void CustomSubscribe();
        protected abstract void CustomUnsubscribe();
        protected abstract void OnPositionChangeHandler(int id, Vector2 position);
        protected abstract void OnHitPointsChangeHandler(int id, int currentHitPoints, int maxHitPoints);
        protected abstract void OnDyingHandler(int id);

        protected void Subscribe()
        {
            if (_entity != null)
            {
                _entity.OnPositionChange += OnPositionChangeHandler;
                _entity.OnHitPointsChange += OnHitPointsChangeHandler;
                _entity.OnDying += OnDyingHandler;
            }

            CustomSubscribe();
        }

        protected void Unsubscribe()
        {
            if (_entity != null)
            {
                _entity.OnPositionChange -= OnPositionChangeHandler;
                _entity.OnHitPointsChange -= OnHitPointsChangeHandler;
                _entity.OnDying -= OnDyingHandler;
            }

            CustomUnsubscribe();
        }
    }
}
