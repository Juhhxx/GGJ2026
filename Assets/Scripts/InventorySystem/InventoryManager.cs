using NaughtyAttributes;
using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    [field: SerializeField] public Vector2 InventorySlotSize { get; private set; }
    [field: SerializeField] public ItemInfo TestItem { get; private set; }
    [field: SerializeField] public GameObject PrefabGrid { get; private set; }
    [field: SerializeField] public GridManager GridManager { get; private set; }

    public static InventoryManager Instance { get; private set; }

    public List<GameObject> Slots { get; set; } = new List<GameObject>();

    private void Awake()
    {
        // Semi Singleton
        Instance = this;
    }


    [Button(enabledMode: EButtonEnableMode.Always)]
    private void SpawnTestItem()
    {
        GameObject go = Instantiate(PrefabGrid, transform);
        GridObject gridObject = go.GetComponent<GridObject>();
        gridObject.SetObject(TestItem);
    }

}
