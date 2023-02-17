namespace Modules.Dungeons.Damage
{
    public interface IDamageable
    {
        int CurrentHitPoints { get; }
        int MaxHitPoints { get; }

        void ChangeHitPoints(int delta);
    }
}
