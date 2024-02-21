using System;

namespace Fighting
{
    public interface IFighterInput
    {
        event Action<string> AbilityPerformed;
        event Action MainAttackPerformed;
        event Action SpecAttackPerformed;

        void Disable();
        void Enable();
    }
}