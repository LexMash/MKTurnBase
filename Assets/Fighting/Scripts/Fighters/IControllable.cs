using System;

namespace Fighting
{
    public interface IControllable
    {
        event Action OnEnabled;
        event Action OnDisabled;
        
        void PerformAbility(int index);
        void PerformMainAttack();
        void PreformSpecAttack();
    }
}