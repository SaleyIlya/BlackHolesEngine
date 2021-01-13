using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews
{
    public class GamePauseView : MonoBehaviour
    {
        [SerializeField] private Button menuButton;
        [SerializeField] private Button unpauseButton;
        [Space]
        [SerializeField] private GameObject gamePauseViewGameObject;
        [Space]
        [SerializeField] private string menuScene;
        
        private GameViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
            menuButton.onClick.AddListener(LoadMainMenu);
            unpauseButton.onClick.AddListener(UnpauseGame);
        }

        private void UnpauseGame()
        {
            _viewModel.SetPauseCommand.Execute(false);
            Destroy(gamePauseViewGameObject);
        }

        private void LoadMainMenu()
        {
            SceneManager.LoadScene(menuScene);
        }
    }
}