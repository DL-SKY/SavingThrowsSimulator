using Modules.Dungeons.Damage;
using Modules.Dungeons.Entities;
using Modules.Dungeons.Movement;
using UnityEngine;

namespace Modules.Dungeons.Entities
{
    public interface IEntity
    {
        string Id { get; }
        Vector2Int Position { get; }
    }
}
