using System;

namespace Fighting
{
    public interface IAttaker
    {
        IFighterBattleData BattleData { get; }

        event Action<AbilityData> AbilityPerformed;
        event Action MainAttackPerformed;
        event Action SpecAttackPerformed;
    }
}