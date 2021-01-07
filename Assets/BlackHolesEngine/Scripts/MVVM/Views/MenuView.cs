using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;
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
        [Header("Prefabs")] 
        [SerializeField] private GameObject shopViewPref;
        [SerializeField] private GameObject inventoryViewPref;
        [SerializeField] private GameObject watchAdvViewPref;

        private MenuViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<MenuViewModel>();
            
            shopButton.onClick.AddListener(() => ShowWindow(shopViewPref));
            inventoryButton.onClick.AddListener(() => ShowWindow(inventoryViewPref));
            watchAdvButton.onClick.AddListener(() => ShowWindow(watchAdvViewPref));
            startButton.onClick.AddListener(StartGame);

            _viewModel.PlayerInGameValue
                .Subscribe(x => UpdateText(goldValueText, x.ToString()))
                .AddTo(this);
            
            _viewModel.PlayerPassedLevel
                .Subscribe(x => UpdateText(levelText, GetPlayerLevelText(x)))
                .AddTo(this);
        }

        private string GetPlayerLevelText(int passedLevel)
        {
            return $"lvl {passedLevel + 1}";
        }

        private void ShowWindow(GameObject pref)
        {
            Instantiate(pref);
        }

        private void StartGame()
        {
            //Todo setup game start here
        }

        private void UpdateText(TextMeshProUGUI tmpText, string text)
        {
            tmpText.text = text;
        }
    }
}