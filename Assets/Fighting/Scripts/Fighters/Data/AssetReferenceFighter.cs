using System;
using UnityEngine.AddressableAssets;

namespace Fighting
{
    [Serializable]
    public class AssetReferenceFighter : AssetReferenceT<FighterView>
    {
        public AssetReferenceFighter(string guid) : base(guid)
        {
        }
    }
}
