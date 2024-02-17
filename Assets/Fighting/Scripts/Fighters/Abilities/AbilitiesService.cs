using System;

namespace Fighting
{
    public class AbilitiesService
    {
        public event Action<string> AbilityAvailable;
        public event Action<string> AbilityNotAvailable;
        public event Action<string, float> AbilityStateUpdated;
    }
}
