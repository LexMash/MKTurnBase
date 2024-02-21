namespace Fighting.UI
{
    public interface IAbilityPanel
    {
        void Init(AbilityData[] abilities);
        void UpdateAbilityState(string abilityID, int turnsRemains);
    }
}