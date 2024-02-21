using System;

namespace Fighting
{
    public class FighterController : IDisposable, IFighterController, IAttaker
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        public event Action MainAttackPerformed;
        public event Action SpecAttackPerformed;
        public event Action<AbilityData> AbilityPerformed;
        public IFighterBattleData BattleData => _data;

        private readonly IFighterInput _input;
        private readonly IAbilityController _abilityController;
        private readonly IAnimationController _animationController;

        private IFighterBattleData _data;
        private FighterView _view;

        public FighterController(
            IAnimationController animationController,
            IFighterInput input,
            IAbilityController abilityController
            )
        {
            _input = input;
            _input.MainAttackPerformed += PerformMainAttack;
            _input.SpecAttackPerformed += PreformSpecAttack;
            _input.AbilityPerformed += PerformAbility;

            _abilityController = abilityController;
            _animationController = animationController;
        }

        public void Dispose()
        {
            _input.MainAttackPerformed -= PerformMainAttack;
            _input.SpecAttackPerformed -= PreformSpecAttack;
            _input.AbilityPerformed -= PerformAbility;
        }

        public void Init(FighterView view, IFighterBattleData data)
        {
            _view = view;
            _data = data;

            _abilityController.CooldownAll();
        }

        public void Enable()
        {
            _input.Enable();

            OnEnabled?.Invoke();
        }

        public void Disable()
        {
            _input.Disable();

            OnDisabled?.Invoke();
        }

        public void TakeOffStun()
        {
            _animationController.PlayIdle();
        }

        public void Stun()
        {
            _animationController.PlayStun();
        }

        public void ApplyBlockState()
        {

        }

        public void ApplyDodgeState()
        {

        }

        public void ApplyDamageState()
        {

        }

        public void ApplyDieState()
        {

        }

        private void PerformAbility(string abilityID)
        {
            _abilityController.CooldownAbility(abilityID);
            AbilityData data = _abilityController.GetAbilityData(abilityID);
            AbilityPerformed?.Invoke(data);
        }

        private void PerformMainAttack()
        {
            MainAttackPerformed?.Invoke();
        }

        private void PreformSpecAttack()
        {
            SpecAttackPerformed?.Invoke();
        }
    }
}
