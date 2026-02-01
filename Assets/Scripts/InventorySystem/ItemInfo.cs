using UnityEngine;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Inventory/New Item")]
public class ItemInfo : ScriptableObject
{
    [field: Header(" Base Item Parameters")]
    [field: Space(5)]
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

    [field: SerializeField] public int StackMaximum { get; private set; }

    [field: SerializeField] public ItemTypes Type { get; private set; }
    [field: SerializeField] public bool IsConsumable { get; private set; }

    [field: SerializeField] public bool DoesStun { get; private set; }

    [field: ShowIf("DoesStun")]
    [field: SerializeField] public float StunDuration { get; private set; }

    [field: ShowIf("DoesStun")]
    [field: SerializeField] public EnemyType StunEnemyType { get; private set; }
    
    [field: Space(10)]
    [field: Header("Item Description")]
    [field: Space(5)]
    [field: SerializeField, ResizableTextArea] public string Description { get; private set; }

    public ItemInfo Instantiate()
    {
        return Instantiate(this);
    }
}
