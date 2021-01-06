﻿using System;
using BlackHoles.BlackHolesEngine.Scripts.Core.ServiceLocator;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using BlackHoles.BlackHolesEngine.Scripts.MVVM.ViewModels;
using TMPro;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField nickname;
        [SerializeField] private TextMeshProUGUI tmpText;
        [SerializeField] private Text text;
        

        private MenuViewModel _viewModel;

        private void Start()
        {
            _viewModel = ServiceLocator.Default.Resolve<MenuViewModel>();
            
            nickname.onEndEdit.AddListener(x =>
            {
                _viewModel.ChangeNicknameCommand.Execute(x);
                nickname.text = "";
                isTest = true;
            });

            _viewModel.User
                .Subscribe(UpdateText).AddTo(this);
        }

        private void UpdateText(User user)
        {
            tmpText.text = user.Nickname;
        }

        bool isTest = false;
        private void LateUpdate()
        {
            if (isTest)
            {
                Debug.Log("test");
                isTest = false;
            }
        }
    }
}