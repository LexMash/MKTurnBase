namespace Fighting
{
    public interface IFighterBattleData
    {
        int Accuracy { get; }
        int CriticalHitChance { get; }
        int RegularAttackDamage { get; }
        int SpecialAttackDamage { get; }
        int Speed { get; }
    }
}