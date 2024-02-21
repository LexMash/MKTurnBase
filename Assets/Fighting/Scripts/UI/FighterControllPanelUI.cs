using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Fighting.UI
{
    public class FighterControllPanelUI : MonoBehaviour, IAbilityPanel, IFighterInput
    {
        [SerializeField] private Button _mainAttackBttn;
        [SerializeField] private Button _specAttackBttn;
        [SerializeField] private List<AbilityButton> _abilityButtons;

        public event Action MainAttackPerformed;
        public event Action SpecAttackPerformed;
        public event Action<string> AbilityPerformed;

        private List<Button> _buttons = new();

        private void OnEnable()
        {
            for (int i = 0; i < _abilityButtons.Count; i++)
                _abilityButtons[i].OnClicked += AbilityButtonClicked;

            _mainAttackBttn.onClick.AddListener(MainAttackBttnClicked);
            _specAttackBttn.onClick.AddListener(SpecAttackBttnClicked);
        }

        private void OnDisable()
        {
            for (int i = 0; i < _abilityButtons.Count; i++)
                _abilityButtons[i].OnClicked -= AbilityButtonClicked;

            _mainAttackBttn.onClick.RemoveListener(MainAttackBttnClicked);
            _specAttackBttn.onClick.RemoveListener(SpecAttackBttnClicked);
        }

        public void Init(AbilityData[] abilityDatas)
        {
            _buttons.Clear();

            _buttons.Add(_mainAttackBttn);
            _buttons.Add(_specAttackBttn);

            for (int i = 0; i < _abilityButtons.Count; i++)
            {
                var abilityData = abilityDatas[i];
                var abilityButton = _abilityButtons[i];

                abilityButton.Init(abilityData.Name, abilityData.IconSprite);
            }
        }

        public void Enable()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].interactable = true;
            }

            for (int k = 0; k < _abilityButtons.Count; k++)
            {
                var bttn = _abilityButtons[k];
                bttn.interactable = bttn.IsAvailable;
            }
        }

        public void Disable()
        {
            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].interactable = false;
            }

            for (int k = 0; k < _abilityButtons.Count; k++)
            {
                _abilityButtons[k].interactable = false;
            }
        }

        public void UpdateSpecialAttackBar(float value)
        {
            //TODO
        }

        public void EnableSpecialAttack()
        {
            //TODO вывести в отдельный класс
        }

        public void UpdateAbilityState(string abilityID, int turnsRemains)
        {
            AbilityButton abilityBttn = _abilityButtons.First(bttn => bttn.AbilityID == abilityID);
            abilityBttn.UpdateState(turnsRemains);
            abilityBttn.AbilityAvailable(turnsRemains == 0);
        }

        private void AbilityButtonClicked(string abilityID) => AbilityPerformed?.Invoke(abilityID);
        private void MainAttackBttnClicked() => MainAttackPerformed?.Invoke();
        private void SpecAttackBttnClicked() => SpecAttackPerformed?.Invoke();
    }
}
