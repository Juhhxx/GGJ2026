using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryShower : MonoBehaviour
{
    [SerializeField] private GameObject _slotUI;

    [SerializeField] private int _inventorySpacing;
    private int _inventoryWidth;
    private int _inventoryHeight;

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

    public List<GameObject> ShowInventory()
    {
        List<GameObject> spawnedSlots = new List<GameObject>();

        if (_inventorySlotParent.childCount > 0) ClearInventory();

        SetUp();

        for (int i = 0; i < _inventoryWidth * _inventoryHeight; i++)
        {
            spawnedSlots.Add(Instantiate(_slotUI, _inventorySlotParent));
        }

        return spawnedSlots;
    }

    public List<GameObject> ShowInventory(int width, int height)
    {
        _inventoryWidth = width;
        _inventoryHeight = height;

        return ShowInventory();
    }

    public void ClearInventory()
    {   
        Transform[] go = _inventorySlotParent.GetComponentsInChildren<Transform>();

        for (int i = 0; i < go.Length; i++)
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
