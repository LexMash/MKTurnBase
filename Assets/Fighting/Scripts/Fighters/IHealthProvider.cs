namespace Fighting
{
    public interface IHealthProvider : IHealthStateNotifier
    {
        void ApplyDamage(int damage);
    }
}