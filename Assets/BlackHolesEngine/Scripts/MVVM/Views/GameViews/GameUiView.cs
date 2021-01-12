using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews
{
    public class GameUiView : MonoBehaviour
    {
        [SerializeField] private Button pauseButton;
        [SerializeField] private TextMeshProUGUI hpLabel;
        [SerializeField] private Image hpImage;
        [Header("Prefabs")]
        [SerializeField] private GamePauseView gamePauseViewPref;

        private GameViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
            pauseButton.onClick.AddListener(PauseButtonAction);

            hpImage.sprite = _viewModel.HpImageSprite;

            _viewModel.PlayerHp.Subscribe(hp =>
                {
                    hpLabel.text = $"{hp} x";
                })
                .AddTo(this);
        }

        private void PauseButtonAction()
        {
            _viewModel.SetPauseCommand.Execute(true);
            Instantiate(gamePauseViewPref);
        }
    }
}