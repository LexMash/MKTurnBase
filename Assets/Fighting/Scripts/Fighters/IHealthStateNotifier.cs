using System;

namespace Fighting
{
    public interface IHealthStateNotifier
    {
        event Action<int> HealthChanged;
        event Action OnDied;
    }
}