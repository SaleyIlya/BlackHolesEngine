using System;
using System.Collections;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class AdvView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button closeButton;
        [SerializeField] private Button getPriceButton;
        [Space]
        [SerializeField] private GameObject closeButtonObject;
        [SerializeField] private GameObject getPriceButtonObject;
        [SerializeField] private GameObject advViewWindow;
        [Header("Prefabs")]
        [SerializeField] private MessageBoxView messageBoxPref;
        [Header("Settings")]
        [SerializeField] private float advTime;
        [SerializeField] private Money priceValue;

        private AdvViewModel _viewModel;
        private bool _canGetPrice = false;
        private bool _isTimerRun = true;
        private float _timerValue = 0f;

        private void Awake()
        {
            getPriceButtonObject.SetActive(false);
            closeButtonObject.SetActive(true);
        }
        
        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<AdvViewModel>();
            
            getPriceButton.onClick.AddListener(GetPriceButtonAction);
            closeButton.onClick.AddListener(CloseWindow);

            Observable.FromMicroCoroutine(AdvTimerCoroutine)
                .Do(_ => OnAdvTimerProcess())
                .DoOnCompleted(OnAdvTimerEnd);
        }

        private IEnumerator AdvTimerCoroutine()
        {
            while (_timerValue < advTime)
            {
                if (_isTimerRun)
                {
                    _timerValue += Time.deltaTime;
                }
                yield return null;
            }
        }

        private void OnAdvTimerProcess()
        {
            Debug.Log(_timerValue);
        }
        
        private void OnAdvTimerEnd()
        {
            _isTimerRun = false;
            _canGetPrice = true;
            closeButtonObject.SetActive(false);
            getPriceButtonObject.SetActive(true);
        }

        private void GetPriceButtonAction()
        {
            if (!_canGetPrice) 
                return;
            
            _viewModel.GetMoneyCommand.Execute(priceValue);
            CloseWindow();
        }

        private void CloseWindow()
        {
            Destroy(advViewWindow);
        }
    }
}