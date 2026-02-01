using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private List<ItemInfo> _items;

    [SerializeField, ReadOnly] private int _currentItemIndex = 0;

    [SerializeField] private Image _currentItemImage;
    [SerializeField] private TextMeshProUGUI _currentItemName;
    [SerializeField] private TextMeshProUGUI _currentItemDescription;

    [SerializeField, InputAxis] private string _itemUseButton = "Fire1";
    [SerializeField] private ItemBehaviour _itemBehaviour;

    public int CurrentItemIndex
    {
        get => _currentItemIndex;
        set
        {
            if (value >= 0 && value < _items.Count)
            {
                _currentItemName.text = _items[value].Name;
                _currentItemDescription.text = _items[value].Description;
                _currentItemImage.sprite = _items[value].Sprite;
                
                _currentItemIndex = value;
            }
        }
    }

    private void Start()
    {
        CurrentItemIndex = 0;
    }

    private void CheckForPlayerSlotSelection()
    {
        if (_items.Count <= 0) return;
        
        for (int i = 0; i < _items.Count; ++i)
            if (Input.GetKeyDown(KeyCode.Alpha1 + i) && i != CurrentItemIndex)
                CurrentItemIndex = i;

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll < 0) CurrentItemIndex += 1;
        else if (scroll > 0) CurrentItemIndex -= 1;
    }

    private void Update()
    {
        CheckForPlayerSlotSelection();

        if (Input.GetButtonDown(_itemUseButton)) UseItem(_items[CurrentItemIndex]);
    }

    private void UseItem(ItemInfo item)
    {
        _itemBehaviour.UseItem(item);
    }
}




// {
//     [SerializeField] private int _inventoryWidth;
//     [SerializeField] private int _inventoryHeight;

//     [SerializeField] private InventoryShower _inventoryShower;

//     [Button(enabledMode: EButtonEnableMode.Always)]
//     private void ShowInventory()
//     {
//         _inventoryShower.ShowInventory(_inventoryWidth, _inventoryHeight);
//     }

//     [Button(enabledMode: EButtonEnableMode.Always)]
//     private void ClearInventory()
//     {
//         _inventoryShower.ClearInventory();
//     }
// }
