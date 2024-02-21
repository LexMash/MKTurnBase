using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class AnimationController : IAnimationController, IDisposable
    {
        private readonly int IDLE_ANIM = Animator.StringToHash("Idle");
        private readonly int STUN_ANIM = Animator.StringToHash("Stun");
        private readonly int DIE_ANIM = Animator.StringToHash("Die");
        private readonly int WIN_ANIM = Animator.StringToHash("Win");
        private readonly int BLOCK_ANIM = Animator.StringToHash("Block");
        private readonly int DODGE_ANIM = Animator.StringToHash("Dodge");
        private readonly int HIT_ANIM = Animator.StringToHash("Hit");
        private readonly int MAIN_ATTACK_ANIM = Animator.StringToHash("MainAttack");
        private readonly int SPEC_ATTACK_ANIM = Animator.StringToHash("SpecAttack");      
        private readonly int ABILITY_FIRST_ANIM = Animator.StringToHash("AbilityFirst");
        private readonly int ABILITY_SECOND_ANIM = Animator.StringToHash("AbilitySecond");

        private readonly Dictionary<int, float> _clipsLengthMap = new();

        private readonly Animator _animator;

        public AnimationController(Animator animator)
        {
            _animator = animator;
        }

        public void Dispose()
        {
            _clipsLengthMap.Clear();
        }

        public void PlayIdle() => _animator.Play(IDLE_ANIM);
        public void PlayStun() => _animator.Play(STUN_ANIM);

        public UniTask PlayAbility(int index)
        {
            throw new NotImplementedException();
        }

        public async UniTask PlayBlock()
        {
            await PlayClip(BLOCK_ANIM);
        }

        public async UniTask PlayDie()
        {
            await PlayClip(DIE_ANIM);
        }

        public async UniTask PlayDodge()
        {
            await PlayClip(DODGE_ANIM);
        }

        public async UniTask PlayHit()
        {
            await PlayClip(HIT_ANIM);
        }
       
        public async UniTask PlayMainAttack()
        {
            await PlayClip(MAIN_ATTACK_ANIM);
        }

        public async UniTask PlaySpecAttack()
        {
            await PlayClip(SPEC_ATTACK_ANIM);
        }       

        public async UniTask PlayWin()
        {
            await PlayClip(WIN_ANIM);
        }

        private async UniTask PlayClip(int stateHash)
        {
            var clipLength = 0f;

            if(_clipsLengthMap.TryGetValue(stateHash, out clipLength) == false) 
            {
                _animator.Play(stateHash);
                clipLength = _animator.GetCurrentAnimatorStateInfo(0).length;
                _clipsLengthMap[stateHash] = clipLength;
            }

            await UniTask.WaitForSeconds(clipLength);
        }
    }
}
