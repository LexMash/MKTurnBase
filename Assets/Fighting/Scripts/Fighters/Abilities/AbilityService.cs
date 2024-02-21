using System;
using System.Collections.Generic;

namespace Fighting
{
    public class AbilityService
    {
        public event Action<string, int> AbilityCooldownUpdated;

        private readonly Dictionary<string, int> _usedAbilityMap = new();

        public void RegisterAbility(string abilityID, int cooldownTurns)
        {
            _usedAbilityMap[abilityID] = cooldownTurns;

            AbilityCooldownUpdated?.Invoke(abilityID, cooldownTurns);
        }

        public void UpdateCooldowns()
        {
            foreach(var kvp in _usedAbilityMap)
            {
                var abilityID = kvp.Key;
                var turnsRemains = kvp.Value - 1;

                AbilityCooldownUpdated?.Invoke(abilityID, turnsRemains);

                if(turnsRemains > 0)
                {
                    _usedAbilityMap[abilityID] = turnsRemains;
                }
                else
                {
                    _usedAbilityMap.Remove(abilityID);
                }              
            }
        }
    }
}
