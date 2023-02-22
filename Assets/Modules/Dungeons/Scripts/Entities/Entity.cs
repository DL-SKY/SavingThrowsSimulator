using Modules.Dungeons.Damage;
using Modules.Dungeons.Movement;
using System;
using UnityEngine;

namespace Modules.Dungeons.Entities
{
    public abstract class Entity : IMoveable, IDamageable
    {
        public event Action<int, Vector2> OnChangePosition;
        public event Action<int, int, int> OnChangeHitPoints;
        public event Action<int> OnDying;

        //IEntity
        public int Id { get; }
        public string ConfigId { get; }

        //IMoveable
        public Vector2 Position { get; protected set; }

        //IDamageable
        public int CurrentHitPoints { get; protected set; }
        public int MaxHitPoints { get; protected set; }
        public bool IsDead => CurrentHitPoints <= 0;


        protected Entity(int id, string configId)
        {
            Id = id;
            ConfigId = configId;
        }


        public void SetPosition(Vector2 position)
        {
            Position = position;
            OnChangePosition?.Invoke(Id, Position);
        }

        public void Move(Vector2 direction)
        {
            SetPosition(Position + direction);
        }

        public void SetHitPoints(int value)
        {
            CurrentHitPoints = GetValidatedHitPoints(value);
            OnChangeHitPoints?.Invoke(Id, CurrentHitPoints, MaxHitPoints);

            if (IsDead)
                OnDying?.Invoke(Id);
        }

        public void ChangeHitPoints(int delta)
        {
            SetHitPoints(CurrentHitPoints + delta);
        }


        protected int GetValidatedHitPoints(int value)
        {
            return Math.Clamp(value, 0, MaxHitPoints);
        }
    }
}
