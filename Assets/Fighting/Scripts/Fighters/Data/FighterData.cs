using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Fighting
{
    [CreateAssetMenu(fileName = "New FighterData", menuName = "Fighting/Fighters/FighterData")]
    public class FighterData : ScriptableObject, IFighterMetaData, IFighterBattleData, IFighterAbilityData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public int MaxHealth { get; private set; }
        [field: SerializeField] public int Accuracy { get; private set; }
        [field: SerializeField] public int Speed { get; private set; }
        [field: SerializeField] public int CriticalHitChance { get; private set; }
        [field: SerializeField] public int RegularAttackDamage { get; private set; }
        [field: SerializeField] public int SpecialAttackDamage { get; private set; }
        [field: SerializeField] public AbilityData[] Abilities { get; private set; }
        [field: SerializeField] public AssetReferenceSprite PortretIcon { get; private set; }
        [field: SerializeField] public AssetReferenceSprite VersusScreenImage { get; private set; }
        [field: SerializeField] public AssetReferenceFighter FighterView { get; private set; }
    }
}
