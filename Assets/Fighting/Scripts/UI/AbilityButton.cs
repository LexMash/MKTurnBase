using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace Fighting.UI
{
    public class AbilityButton : Button, IAbilityButton
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Image _disableCoverImage;
        [SerializeField] private TextMeshProUGUI _counterLabel;

        public event Action<string> OnClicked;
        public string AbilityID { get; private set; }
        public bool IsAvailable { get; private set; }

        public void Init(string actionID, Sprite iconSprite)
        {
            AbilityID = actionID;
            _icon.sprite = iconSprite;
            _disableCoverImage.enabled = true;
        }

        public void UpdateState(int turnsRemaining) 
            => _counterLabel.text = turnsRemaining > 0 ? turnsRemaining.ToString() : string.Empty;

        public void AbilityAvailable(bool isAvailable)
        {
            IsAvailable = isAvailable;
            _disableCoverImage.enabled = IsAvailable;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
            OnClicked?.Invoke(AbilityID);
        }
    }
}
