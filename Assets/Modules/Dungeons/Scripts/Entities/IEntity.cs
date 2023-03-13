using System;

namespace Modules.Dungeons.Entities
{
    public interface IEntity
    {
        /// <summary>
        /// int => Id
        /// </summary>
        event Action<int> OnTurnDone;

        int Id { get; }
        string ConfigId { get; }

        void Update(float deltaTime);
        void RefreshTurn();
    }
}
