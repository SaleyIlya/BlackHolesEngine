using System;
using BlackHoles.BlackHolesEngine.Scripts.DataModel.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class MarketplaceSelectorButtonView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buttonLabel;
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        [Space]
        [SerializeField] private Sprite selectedSprite;
        [SerializeField] private Sprite deselectedSprite;

        private Action<MarketplaceSelectorButtonView> _buttonAction;
        private ItemType _type;
        private bool _isSelected;
        
        public ItemType Type => _type;
        public bool IsSelected => _isSelected;

        public void Init(ItemType type, Action<MarketplaceSelectorButtonView> buttonAction)
        {
            _type = type;
            buttonLabel.text = type.ToString();
            _buttonAction = buttonAction;
            ChangeButtonState(false);
            
            button.onClick.AddListener(ButtonAction);
        }

        private void ButtonAction()
        {
            if (_isSelected)
            {
                return;
            }
            
            _buttonAction.Invoke(this);
        }

        public void ChangeButtonState(bool newState)
        {
            _isSelected = newState;
            image.sprite = _isSelected ? selectedSprite : deselectedSprite;
        }
    }
}