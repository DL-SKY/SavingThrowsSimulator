using Modules.Dungeons.Entities;
using System;
using UnityEngine;

namespace Modules.Dungeons.Movement
{
    public interface IMoveable : IEntity
    {
        /// <summary>
        /// int, Vector2 => Id, NewPosition
        /// </summary>
        event Action<int, Vector2> OnChangePosition;

        Vector2 Position { get; }

        void SetPosition(Vector2 position);
        void Move(Vector2 direction);
    }
}
