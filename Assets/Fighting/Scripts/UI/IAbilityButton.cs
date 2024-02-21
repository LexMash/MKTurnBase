using System;

namespace Fighting.UI
{
    public interface IAbilityButton
    {
        event Action<string> OnClicked;

        void AbilityAvailable(bool isAvailable);
        void UpdateState(int turnsRemaining);
    }
}