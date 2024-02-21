using Fighting.UI;
using System;
using System.Collections.Generic;

namespace Fighting
{
    public class AbilityController : IDisposable, IAbilityController
    {
        public event Action<string> AbilityAvailable;

        private readonly IAbilityPanel _abilityPanel;
        private readonly AbilityService _abilityService;
        private readonly Dictionary<string, AbilityData> _abilityDataMap = new();

        public AbilityController(IAbilityPanel abilityPanel, AbilityService abilityService, AbilityData[] abilityDatas)
        {
            _abilityPanel = abilityPanel;
            _abilityService = abilityService;

            for (int i = 0; i < abilityDatas.Length; i++)
                _abilityDataMap[abilityDatas[i].Name] = abilityDatas[i];

            _abilityService.AbilityCooldownUpdated += AbilityCooldownUpdated;
        }

        public AbilityData GetAbilityData(string abilityID) => _abilityDataMap[abilityID];

        public void CooldownAbility(string abilityID)
        {
            var data = GetAbilityData(abilityID);
            _abilityService.RegisterAbility(abilityID, data.Cooldown);
        }

        public void CooldownAll()
        {
            foreach(var kvp in _abilityDataMap)
                _abilityService.RegisterAbility(kvp.Key, kvp.Value.Cooldown);
        }

        public void Dispose()
        {
            _abilityService.AbilityCooldownUpdated -= AbilityCooldownUpdated;
            _abilityDataMap.Clear();
        }

        private void AbilityCooldownUpdated(string abilityID, int turnsRemaining)
        {
            if (_abilityDataMap.ContainsKey(abilityID))
            {
                _abilityPanel.UpdateAbilityState(abilityID, turnsRemaining);

                if (turnsRemaining == 0)
                    AbilityAvailable?.Invoke(abilityID);
            }
        }
    }
}
