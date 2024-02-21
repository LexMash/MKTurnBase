using Cysharp.Threading.Tasks;

namespace Fighting
{
    public interface IAnimationController
    {
        void PlayIdle();
        void PlayStun();
        UniTask PlayMainAttack();
        UniTask PlaySpecAttack();
        UniTask PlayAbility(int index);
        UniTask PlayDodge();
        UniTask PlayHit();
        UniTask PlayBlock();
        UniTask PlayDie();
        UniTask PlayWin();
    }
}