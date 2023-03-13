using Modules.Dungeons.Entities;
using System;

namespace Modules.Dungeons.Activity
{
    public interface IActive : IEntity
    {
        /// <summary>
        /// int, int => Id, CurrentActionPoints
        /// </summary>
        event Action<int, int> OnActionPointsChange;

        int MaxActionPoints { get; }
        int CurrentActionPoints { get; }
    }
}
