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
        event Action<int, Vector2> OnPositionChange;

        /// <summary>
        /// int => Id
        /// </summary>
        event Action<int> OnMoveDone;

        bool IsMoving { get; }
        Vector2 Position { get; }

        void SetPosition(Vector2 position, bool isTeleportation);
        void StartMove(Vector2 direction);
    }
}
