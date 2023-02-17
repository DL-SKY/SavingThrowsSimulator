using UnityEngine;

namespace Modules.Dungeons.Movement
{
    public interface IMoveable
    {
        void Move(Vector2Int direction);
    }
}
