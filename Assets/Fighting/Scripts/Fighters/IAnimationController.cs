using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Fighting
{
    public interface IAnimationController
    {
        bool IsPlay { get; }

        void Setup(Animator animator);
        void PlayIdle();
        void PlayStun();
        UniTask PlayMainAttack();
        UniTask PlaySpecAttack();
        UniTask PlayAbility(int index);
        UniTask PlayDodge();
        UniTask PlayHit();
        UniTask PlayBlock();
    }
}