using System;

namespace Fighting
{
    public interface IHealthStateNotifier
    {
        event Action<int> OnDamaged;
        event Action OnDied;
    }
}