using Modules.Dungeons.Damage;
using Modules.Dungeons.Movement;
using System;
using UnityEngine;

namespace Modules.Dungeons.Entities
{
    public abstract class Entity : IMoveable, IDamageable
    {
        protected const float MOVE_DURATION = 0.25f;
        protected const float MOVE_EPSILON = 0.0001f;

        public event Action<int, Vector2> OnPositionChange;
        public event Action<int> OnMoveDone;
        public event Action<int, int, int> OnHitPointsChange;
        public event Action<int> OnDying;        

        //IEntity
        public int Id { get; }
        public string ConfigId { get; }

        //IMoveable
        public bool IsMoving { get; protected set; }
        public Vector2 Position { get; protected set; }

        protected Vector2 _targetPosition;
        protected abstract int SpeedPointsPerTurn { get; }
        protected abstract int MaxSpeedPoints { get; }
        protected int _currentSpeedPoints;

        //IDamageable
        public int CurrentHitPoints { get; protected set; }
        public abstract int MaxHitPoints { get; }
        public bool IsDead => CurrentHitPoints <= 0;
        

        protected Entity(int id, string configId)
        {
            Id = id;
            ConfigId = configId;
        }


        public virtual void Update(float deltaTime)
        {
            TryMove(deltaTime);
        }

        public virtual void RefreshTurn()
        {
            //SpeedPoints
            _currentSpeedPoints += SpeedPointsPerTurn;
            _currentSpeedPoints = Mathf.Clamp(_currentSpeedPoints, 0, MaxSpeedPoints);
        }


        public void SetPosition(Vector2 position, bool isTeleportation = false)
        {
            Position = position;
            _targetPosition = isTeleportation ? position : _targetPosition;
            OnPositionChange?.Invoke(Id, Position);
        }

        public void StartMove(Vector2 direction)
        {
            if (!CheckMoving())
                _targetPosition = Position + direction;
            else
                UnityEngine.Debug.LogError($"Moving not done!");
        }

        public void SetHitPoints(int value)
        {
            CurrentHitPoints = GetValidatedHitPoints(value);
            OnHitPointsChange?.Invoke(Id, CurrentHitPoints, MaxHitPoints);

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

        protected void TryMove(float deltaTime)
        {
            if (!CheckMoving())
            {
                return;
            }

            if (IsDead)
            {
                _targetPosition = Position;
                OnMoveDone?.Invoke(Id);
                return;
            }

            var distanceDelta = 1.0f * (deltaTime / MOVE_DURATION);
            var newPosition = Vector2.MoveTowards(Position, _targetPosition, distanceDelta);
            SetPosition(newPosition);
        }

        protected bool CheckMoving()
        {
            var state = (_targetPosition - Position).sqrMagnitude > MOVE_EPSILON;
            if (IsMoving && !state)
            {
                IsMoving = state;
                OnMoveDone?.Invoke(Id);
            }
            else
            {
                IsMoving = state;
            }

            return IsMoving;
        }
    }
}
