using System;

namespace Fighting
{
    public interface IAbilityAvaliableNotifier
    {
        event Action<string> AbilityAvailable;
    }
}