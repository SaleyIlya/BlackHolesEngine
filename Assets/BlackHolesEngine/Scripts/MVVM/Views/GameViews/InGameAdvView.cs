using System;
using System.Collections;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views.GameViews
{
    public class InGameAdvView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button continueButton;
        [SerializeField] private TextMeshProUGUI timeText;
        [Space]
        [SerializeField] private GameObject closeButtonObject;
        [SerializeField] private GameObject continueButtonObject;
        [SerializeField] private GameObject advViewWindow;
        [Space]
        [SerializeField] private Image closeButtonImage;
        [Header("Settings")]
        [SerializeField] private float advTime;
        
        private GameViewModel _viewModel;
        private IDisposable _disposable;
        
        private bool _isTimerRun = true;
        private float _timerValue = 0f;

        private void Awake()
        {
            continueButtonObject.SetActive(false);
            closeButtonObject.SetActive(true);
        }
        
        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<GameViewModel>();
            
            continueButton.onClick.AddListener(ContinueGame);

            _disposable = Observable.FromCoroutine(AdvTimerCoroutine)
                .Subscribe(_ => OnAdvTimerEnd());
        }

        private IEnumerator AdvTimerCoroutine()
        {
            while (_timerValue < advTime)
            {
                closeButtonImage.fillAmount = _timerValue / advTime;
                timeText.text = ((int)(advTime - _timerValue)).ToString();
                if (_isTimerRun)
                {
                    _timerValue += Time.deltaTime;
                }

                yield return null;
            }
        }

        private void OnAdvTimerEnd()
        {
            _isTimerRun = false;
            closeButtonObject.SetActive(false);
            continueButtonObject.SetActive(true);
        }

        private void ContinueGame()
        {
            _viewModel.ResetPlayerHpCommand.Execute();
            _viewModel.SetPauseCommand.Execute(false);
            Destroy(advViewWindow);
        }

        private void OnDisable()
        {
            _disposable.Dispose();
        }
    }
}