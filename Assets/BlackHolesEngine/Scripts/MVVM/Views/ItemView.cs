using System;
using BlackHoles.BlackHolesEngine.Scripts.DataModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlackHoles.BlackHolesEngine.Scripts.MVVM.Views
{
    public class ItemView : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Button buyButton;
        [SerializeField] private Button selectButton;
        [Space]
        [SerializeField] private Image itemImage;
        [SerializeField] private TextMeshProUGUI coatText;
        [Space]
        [SerializeField] private GameObject costGameObject;
        [SerializeField] private GameObject lockedGameObject;
        [SerializeField] private GameObject selectedGameObject;

        private ShopItem _shopItem;
        private InventoryItem _inventoryItem;

        public void InitShopItem(Item item, ShopItem shopItem, bool isLocked, Func<ShopItem, bool> buttonAction)
        {
            selectedGameObject.SetActive(false);
            costGameObject.SetActive(true);
            lockedGameObject.SetActive(isLocked);
            _shopItem = shopItem;

            selectButton.gameObject.SetActive(false);

            if (!isLocked)
            {
                buyButton.onClick.AddListener(() => buttonAction.Invoke(_shopItem));
            }
            else
            {
                buyButton.gameObject.SetActive(false);
            }
            
            SetupView(item, shopItem);
        }

        public void InitInventoryItem(Item item, InventoryItem inventoryItem, bool isSelected, Func<InventoryItem, bool> buttonAction)
        {
            costGameObject.SetActive(false);
            lockedGameObject.SetActive(false);
            selectedGameObject.SetActive(isSelected);
            _inventoryItem = inventoryItem;

            buyButton.gameObject.SetActive(false);

            if (!isSelected)
            {
                selectButton.onClick.AddListener(() => buttonAction.Invoke(_inventoryItem));
            }
            else
            {
                selectButton.gameObject.SetActive(false);
            }
            
            SetupView(item, inventoryItem);
        }

        private void SetupView(Item item)
        {
            itemImage.sprite = item.ItemIcon;
            itemImage.preserveAspect = true;
        }
        
        private void SetupView(Item item, ShopItem shopItem)
        {
            SetupView(item);

            coatText.text = $"coast - {shopItem.Cost.InGameValue}";
        }
        
        private void SetupView(Item item, InventoryItem inventoryItem)
        {
            SetupView(item);
        }
    }
}