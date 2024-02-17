using UnityEngine.AddressableAssets;

namespace Fighting
{
    public interface IFighterMetaData
    {
        string Description { get; }
        int MaxHealth { get; }
        string Name { get; }
        AssetReferenceSprite PortretIcon { get; }
        AssetReferenceSprite VersusScreenImage { get; }
    }
}