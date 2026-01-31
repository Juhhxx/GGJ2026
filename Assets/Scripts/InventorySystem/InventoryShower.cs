using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Jobs;
using UnityEngine.UI;

public class InventoryShower : MonoBehaviour
{
    [SerializeField] private GameObject _slotUI;

    [SerializeField] private int _inventorySpacing;
    [SerializeField] private int _inventoryWidth;
    [SerializeField] private int _inventoryHeight;

    [SerializeField] private Vector2 _inventorySlotSize;

    [SerializeField] private Transform _inventorySlotParent;

    private GridLayoutGroup _gridLayoutGroup;

    private void SetUp()
    {
        _gridLayoutGroup = _inventorySlotParent.GetComponent<GridLayoutGroup>();
        _gridLayoutGroup.cellSize = _inventorySlotSize;
        _gridLayoutGroup.spacing = new Vector2(_inventorySpacing, _inventorySpacing);
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _inventoryWidth;
    }

    [Button(enabledMode: EButtonEnableMode.Always)]
    public void ShowInventory()
    {
        if (_inventorySlotParent.childCount > 1) ClearInventory();

        SetUp();

        for (int i = 0; i < _inventoryWidth * _inventoryHeight; i++)
        {
            Instantiate(_slotUI, _inventorySlotParent);
        }
    }

    public void ShowInventory(int width, int height)
    {
        _inventoryWidth = width;
        _inventoryHeight = height;

        if (_inventorySlotParent.childCount > 1) ClearInventory();

        SetUp();

        for (int i = 0; i < _inventoryWidth * _inventoryHeight; i++)
        {
            Instantiate(_slotUI, _inventorySlotParent);
        }
    }

    [Button(enabledMode: EButtonEnableMode.Always)]
    public void ClearInventory()
    {
        Transform[] go = _inventorySlotParent.GetComponentsInChildren<Transform>();

        for (int i = 1; i < go.Length; i++)
        {
            if (go[i] != _inventorySlotParent)
            {
#if UNITY_EDITOR
                DestroyImmediate(go[i].gameObject);
#else
                Destroy(go[i].gameObject);
#endif
            }
        }
    }
}
