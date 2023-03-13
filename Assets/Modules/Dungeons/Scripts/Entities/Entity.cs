using Modules.Dungeons.Activity;
using Modules.Dungeons.Damage;
using Modules.Dungeons.Movement;
using System;
using UnityEngine;

namespace Modules.Dungeons.Entities
{
    public abstract class Entity : IMoveable, IDamageable, IActive
    {
        protected const float MOVE_DURATION = 0.25f;
        protected const float MOVE_EPSILON = 0.0001f;

        public event Action<int> OnTurnDone;

        public event Action<int> OnMoveDone;
        public event Action<int, int> OnSpeedPointsChange;
        public event Action<int, Vector2> OnPositionChange;
        public event Action<int, float> OnAngleChange;

        public event Action<int, int, int> OnHitPointsChange;
        public event Action<int> OnDying;

        public event Action<int, int> OnActionPointsChange;

        //IEntity
        public int Id { get; }
        public string ConfigId { get; }

        //IMoveable
        public bool IsMoving { get; protected set; }
        public Vector2 Position { get; protected set; }
        public float Angle { get; protected set; }
        protected abstract int SpeedPointsPerTurn { get; }
        public abstract int MaxSpeedPoints { get; }
        public int CurrentSpeedPoints { get; protected set; }
        public abstract int StepCost { get; }

        protected Vector2 _targetPosition;
        protected float _targetAngle;        

        //IDamageable
        public int CurrentHitPoints { get; protected set; }
        public abstract int MaxHitPoints { get; }
        public bool IsDead => CurrentHitPoints <= 0;

        //IActive
        protected abstract int ActionPointsPerTurn { get; }
        public abstract int MaxActionPoints { get; }
        public int CurrentActionPoints { get; protected set; }


        protected Entity(int id, string configId)
        {
            Id = id;
            ConfigId = configId;
        }


        public virtual void Update(float deltaTime)
        {
            TryMove(deltaTime);
            TryRotate(deltaTime);
        }

        public virtual void RefreshTurn()
        {
            //TODO...
            //...

            RefreshSpeedPoints();
            RefreshActionPoints();
        }

        public void RefreshSpeedPoints()
        {
            CurrentSpeedPoints += SpeedPointsPerTurn;
            CurrentSpeedPoints = Mathf.Clamp(CurrentSpeedPoints, 0, MaxSpeedPoints);
        }

        public void RefreshActionPoints()
        {
            CurrentActionPoints += ActionPointsPerTurn;
            CurrentActionPoints = Mathf.Clamp(CurrentActionPoints, 0, MaxActionPoints);
        }

        public void SetPosition(Vector2 position, bool isTeleportation = false)
        {
            Position = position;
            _targetPosition = isTeleportation ? position : _targetPosition;
            OnPositionChange?.Invoke(Id, Position);
        }

        public void StartMove(Vector2 direction)
        {
            //SpeedPoints
            if (!CheckSpeedPoints(StepCost))
            {
                UnityEngine.Debug.LogError($"Not enough Speed Points");
                return;
            }

            //Moving
            if (!CheckMoving())
            {
                _targetPosition = Position + direction;
                CurrentSpeedPoints -= StepCost;
                OnSpeedPointsChange?.Invoke(Id, CurrentSpeedPoints);
            }
            else
            {
                UnityEngine.Debug.LogError($"Moving not done!");
            }
        }

        public void SetAngle(float angle, bool isTeleportation = false)
        {
            Angle = ValidateAngle(angle);
            _targetAngle = ValidateAngle(isTeleportation ? angle : _targetAngle);

            OnAngleChange?.Invoke(Id, Angle);
        }

        public void StartRotate(float deltaAngle)
        {
            //Rotating
            if (!CheckMoving())
            {
                _targetAngle = Angle + deltaAngle;
            }
            else
            {
                UnityEngine.Debug.LogError($"Moving not done!");
            }
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

        public bool CheckSpeedPoints(int pointsNeeded)
        {
            return CurrentSpeedPoints >= pointsNeeded;
        }

        public bool CheckSpeedPoints()
        {
            return CheckSpeedPoints(StepCost);
        }

        public bool CheckActionPoints(int pointsNeeded)
        {
            return CurrentActionPoints >= pointsNeeded;
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

            if (CanMove())
            {
                var distanceDelta = 1.0f * (deltaTime / MOVE_DURATION);
                var newPosition = Vector2.MoveTowards(Position, _targetPosition, distanceDelta);
                SetPosition(newPosition);
            }
        }        

        protected void TryRotate(float deltaTime)
        {
            if (!CheckMoving())
            {
                return;
            }

            if (IsDead)
            {
                _targetAngle = Angle;
                OnMoveDone?.Invoke(Id);
                return;
            }

            if (CanRotate())
            {
                var rotateDelta = 90.0f * (deltaTime / MOVE_DURATION);
                var newAngle = Mathf.MoveTowards(Angle, _targetAngle, rotateDelta);
                SetAngle(newAngle);
            }
        }        

        protected bool CheckMoving()
        {
            var stateMove = CanMove();
            var stateRotate = CanRotate();

            var state = stateMove || stateRotate;
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

        private bool CanMove()
        { 
            return (_targetPosition - Position).sqrMagnitude > MOVE_EPSILON;
        }

        private bool CanRotate()
        {
            return Mathf.Abs(_targetAngle - Angle) > MOVE_EPSILON;
        }

        private float ValidateAngle(float originAngle)
        {
            if (originAngle > 360.0f)
                return originAngle - 360.0f;
            else if (originAngle < -360.0f)
                return originAngle + 360.0f;
            else
                return originAngle;
        }
    }
}
