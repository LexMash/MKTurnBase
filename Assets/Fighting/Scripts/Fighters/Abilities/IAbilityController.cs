namespace Fighting
{
    public interface IAbilityController : IAbilityAvaliableNotifier
    {       
        void CooldownAll();
        void CooldownAbility(string abilityID);
        AbilityData GetAbilityData(string abilityID);
    }
}