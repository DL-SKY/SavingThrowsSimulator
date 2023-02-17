using UnityEngine;

namespace Modules.Dungeons.Entities
{
    public abstract class Entity : IEntity
    {
        public string Id => throw new System.NotImplementedException();

        public Vector2Int Position => throw new System.NotImplementedException();
    }
}
