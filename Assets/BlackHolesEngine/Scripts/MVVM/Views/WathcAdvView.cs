using System;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class WathcAdvView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button watchButton;
        [SerializeField] private GameObject watchAdvViewObj;
        [Header("Prefabs")]
        [SerializeField] private GameObject advPanelView;

        private void Start()
        {
            closeButton.onClick.AddListener(ClosePanel);
            watchButton.onClick.AddListener(StartWatchAdv);
        }

        private void ClosePanel()
        {
            Destroy(watchAdvViewObj);
        }

        private void StartWatchAdv()
        {
            Instantiate(advPanelView);
            ClosePanel();
        }
    }
}