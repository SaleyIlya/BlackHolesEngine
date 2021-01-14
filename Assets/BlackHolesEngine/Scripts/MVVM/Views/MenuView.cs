using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class MenuView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button settingsButton;
        [SerializeField] private Button shopButton;
        [SerializeField] private Button inventoryButton;
        [SerializeField] private Button watchAdvButton;
        [SerializeField] private Button startButton;
        [Space]
        [SerializeField] private TextMeshProUGUI goldValueText;
        [SerializeField] private TextMeshProUGUI levelText;
        [Space]
        [SerializeField] private GameObject soundGameObject;
        [SerializeField] private GameObject vibrationGameObject;
        [Header("Prefabs")] 
        [SerializeField] private GameObject shopViewPref;
        [SerializeField] private GameObject inventoryViewPref;
        [SerializeField] private GameObject watchAdvViewPref;
        [Header("GameSceneName")] 
        [SerializeField] private string gameSceneName;

        

        private MenuViewModel _viewModel;
        private bool _isSettingHide = true;

        private void Awake()
        {
            _isSettingHide = true;
            SetupSettingsVisibility(true);
        }

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<MenuViewModel>();
            
            settingsButton.onClick.AddListener(() => SetupSettingsVisibility(!_isSettingHide));
            shopButton.onClick.AddListener(() => ShowWindow(shopViewPref));
            inventoryButton.onClick.AddListener(() => ShowWindow(inventoryViewPref));
            watchAdvButton.onClick.AddListener(() => ShowWindow(watchAdvViewPref));
            startButton.onClick.AddListener(LoadGameScene);

            _viewModel.PlayerInGameValue
                .Subscribe(x => UpdateText(goldValueText, x.ToString()))
                .AddTo(this);
            
            _viewModel.PlayerPassedLevel
                .Subscribe(x =>
                {
                    if (x <= _viewModel.FinalLevelNumber)
                    {
                        UpdateText(levelText, GetPlayerLevelText(x));
                    }
                    else
                    {
                        startButton.interactable = false;
                        UpdateText(levelText, "coming soon..");
                    }
                })
                .AddTo(this);
        }

        private void LoadGameScene()
        {
            var levelToLoad = _viewModel.PlayerPassedLevel.Value + 1;
            ServiceLocator.Default.Resolve<GameViewModel>().InitLevelCommand.Execute(levelToLoad);
            SceneManager.LoadScene(gameSceneName);
        }
        
        private void SetupSettingsVisibility(bool isHidden)
        {
            _isSettingHide = isHidden;
            soundGameObject.SetActive(!_isSettingHide);
            vibrationGameObject.SetActive(!_isSettingHide);
        }

        private string GetPlayerLevelText(int passedLevel)
        {
            return $"lvl {passedLevel + 1}";
        }

        private void ShowWindow(GameObject pref)
        {
            Instantiate(pref);
        }

        private void UpdateText(TextMeshProUGUI tmpText, string text)
        {
            tmpText.text = text;
        }
    }
}