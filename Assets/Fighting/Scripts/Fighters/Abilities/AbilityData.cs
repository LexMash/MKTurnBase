using UnityEngine;

namespace Fighting
{
    public class AbilityData : ScriptableObject
    {
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public string Description { get; private set; }
        [field: SerializeField, Range(0, 50)] public int Damage { get; private set; }
        [field:SerializeField, Range(0, 10)] public int Cooldown { get; private set; }
        [field:SerializeField] public Sprite IconSprite { get; private set; }
    }
}