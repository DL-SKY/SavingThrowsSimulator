namespace Modules.Dungeons.Entities
{
    public interface IEntity
    {
        int Id { get; }
        string ConfigId { get; }

        void Update(float deltaTime);
    }
}
