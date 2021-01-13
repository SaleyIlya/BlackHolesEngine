using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews
{
    public class DeathScreenView : MonoBehaviour
    {
        [SerializeField] private string menuScene;
        [Header("Ui")]
        [SerializeField] private Button menuButton;
        [SerializeField] private Button watchAdvButton;
        [Space]
        [SerializeField] private GameObject deathScreenViewGameObject;
        [SerializeField] private GameObject watchAdvButtonGameObject;
        [Header("Prefabs")]
        [SerializeField] private InGameAdvView inGameAdvViewPrefab;

        private GameViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<GameViewModel>();

            if (_viewModel.PlayerAttempts.Value <= 0)
            {
                watchAdvButtonGameObject.SetActive(false);
            }
            
            watchAdvButton.onClick.AddListener(WatchAdvButtonAction);
            menuButton.onClick.AddListener(MenuButtonAction);
        }

        private void MenuButtonAction()
        {
            SceneManager.LoadScene(menuScene);
        }

        private void WatchAdvButtonAction()
        {
            _viewModel.ChangePlayerAttemptCommand.Execute();
            Instantiate(inGameAdvViewPrefab);
            Destroy(deathScreenViewGameObject);
        }
    }
}