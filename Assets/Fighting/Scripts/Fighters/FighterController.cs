using System;

namespace Fighting
{
    public class FighterController : IControllable
    {
        public event Action OnEnabled;
        public event Action OnDisabled;

        private readonly IHealthStateNotifier _healthNotifier;
        private readonly IBattleCalculator _battleCalculator;
        private readonly IAnimationController _animationController;

        private FighterView _view;

        public FighterController(
            IHealthStateNotifier healthNotifier, 
            IBattleCalculator battleCalculator, 
            IAnimationController animationController)
        {
            _healthNotifier = healthNotifier;
            _healthNotifier.OnDamaged += OnDamaged;
            _healthNotifier.OnDied += OnDied;

            _battleCalculator = battleCalculator;

            _animationController = animationController;
        }

        public void Setup(IFighterMetaData metaData, FighterView view)
        {
            _view = view;

            _animationController.Setup(_view.Animator);
        }

        public void TurnStart()
        {                   
            OnEnabled?.Invoke();
        }

        public void TurnEnd()
        {
            OnDisabled?.Invoke();
        }

        public void PerformAbility(int index)
        {

        }

        public void PerformMainAttack()
        {

        }

        public void PreformSpecAttack()
        {

        }

        public void ApplyStunState()
        {

        }

        public void ApplyBlockState()
        {

        }

        public void ApplyDodgeState()
        {

        }

        private void OnDied()
        {

        }

        private void OnDamaged(int value)
        {

        }
    }
}
