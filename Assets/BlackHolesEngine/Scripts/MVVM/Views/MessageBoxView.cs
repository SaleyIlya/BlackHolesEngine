using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class MessageBoxView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        [Space]
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private TextMeshProUGUI leftButtonText;
        [SerializeField] private TextMeshProUGUI rightButtonText;
        [Space]
        [SerializeField] private GameObject messageBoxViewGameObject;
        [SerializeField] private GameObject leftButtonGameObject;
        [SerializeField] private GameObject rightButtonGameObject;
        
        public void InitWithOneButton(string message, string buttonLabel, Action buttonAction)
        {
            leftButtonGameObject.SetActive(true);
            rightButtonGameObject.SetActive(false);
            
            messageText.text = message;
            leftButtonText.text = buttonLabel;
            leftButton.onClick.AddListener(() => CloseWindowsWithAction(buttonAction));
        }
        
        public void InitWithTwoButtons(string message, 
            string leftButtonLabel, Action leftButtonAction,
            string rightButtonLabel, Action rightButtonAction)
        {
            leftButtonGameObject.SetActive(true);
            rightButtonGameObject.SetActive(true);
            
            messageText.text = message;
            leftButtonText.text = leftButtonLabel;
            rightButtonText.text = rightButtonLabel;
            leftButton.onClick.AddListener(() => CloseWindowsWithAction(leftButtonAction));
            rightButton.onClick.AddListener(() => CloseWindowsWithAction(rightButtonAction));
        }

        private void CloseWindowsWithAction(Action action)
        {
            action.Invoke();
            Destroy(messageBoxViewGameObject);
        }
    }
}