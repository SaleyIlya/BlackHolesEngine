using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public enum SettingButtonType
    {
        Sound,
        Vibration
    }
    
    public class SettingButtonView : MonoBehaviour
    {
        [SerializeField] private SettingButtonType buttonType;
        [SerializeField] private Button button;
        [SerializeField] private Image buttonImage;
        [Space]
        [SerializeField] private Sprite activeSprite;
        [SerializeField] private Sprite inactiveSprite;

        private SettingsViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<SettingsViewModel>();

            SetupButton();
        }

        private void SetupButton()
        {
            switch (buttonType)
            {
                case SettingButtonType.Sound:
                    button.onClick.AddListener(() => _viewModel.ChangeSoundValue.Execute());
                    _viewModel.Sound
                        .Subscribe(SetupButtonView)
                        .AddTo(this);
                    break;
                case SettingButtonType.Vibration:
                    button.onClick.AddListener(() => _viewModel.ChangeVibrationValue.Execute());
                    _viewModel.Vibration
                        .Subscribe(SetupButtonView)
                        .AddTo(this);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetupButtonView(bool isActive)
        {
            buttonImage.sprite = isActive ? activeSprite : inactiveSprite;
        }
    }
}