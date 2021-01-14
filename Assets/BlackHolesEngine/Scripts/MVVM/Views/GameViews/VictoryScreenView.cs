using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews
{
    public class VictoryScreenView : MonoBehaviour
    {
        [SerializeField] private string menuScene;
        [Header("Ui")]
        [SerializeField] private Button menuButton;
        [SerializeField] private TextMeshProUGUI priceText;

        private GameViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
            priceText.text = _viewModel.LevelSettings.LevelInGameValuePrice.ToString();
            
            menuButton.onClick.AddListener(MenuButtonAction);
        }

        private void MenuButtonAction()
        {
            _viewModel.GetLevelPriceCommand.Execute();
            SceneManager.LoadScene(menuScene);
        }
    }
}