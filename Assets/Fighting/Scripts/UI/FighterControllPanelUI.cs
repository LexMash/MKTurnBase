using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fighting.UI
{
    public class FighterControllPanelUI : MonoBehaviour
    {
        [SerializeField] private Transform _buttonsParent;

        public Action RegularAttackPerform;
        public Action SpecAttackPerform;
        public Action<int> AbilityPerform;

        private List<Button> _buttons = new();
        private List<AbilityButton> _abilityButtons = new();
        
        public void Init(AbilityData[] abilities)
        {
            //создаём кнопки
        }

        public void Enable()
        {
            //делаем панель активной когда ход персонажа

            for(int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].interactable = true;
            }
        }

        public void Disable()
        {
            //отключаем панель когда чужой ход

            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons[i].interactable = false;
            }
        }

        public void EnableSpecialAttack()
        {

        }
    }
}
