using Modules.Dungeons.Entities;
using System;

namespace Modules.Dungeons.Damage
{
    public interface IDamageable : IEntity
    {
        /// <summary>
        /// int, int, int => Id, CurrentHP, MaxHP
        /// </summary>
        event Action<int, int, int> OnHitPointsChange;

        /// <summary>
        /// int => Id
        /// </summary>
        event Action<int> OnDying;

        int CurrentHitPoints { get; }
        int MaxHitPoints { get; }

        bool IsDead { get; }

        void ChangeHitPoints(int delta);
        void SetHitPoints(int value);
    }
}
