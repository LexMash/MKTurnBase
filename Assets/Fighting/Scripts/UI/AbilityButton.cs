using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Fighting.UI
{
    public class AbilityButton : Button
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _reloadIcon;

        public event Action<int> OnClicked;

        private int _index;

        public void Setup(int index, Sprite iconSprite)
        {
            _index = index;
            _icon.sprite = iconSprite;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            OnClicked?.Invoke(_index);
        }
    }
}
