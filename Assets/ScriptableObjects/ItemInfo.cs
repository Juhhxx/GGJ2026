using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Scriptable Objects/ItemInfo")]
public class ItemInfo : ScriptableObject
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField, ShowAssetPreview] public Sprite Sprite { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    [field: SerializeField] public int Width { get; private set; }
    [field: SerializeField] public int Height { get; private set; }
}

public class Item
{
    [field: SerializeField] public string DisplayName { get; private set; }
    [field: SerializeField, ShowAssetPreview] public Sprite Sprite { get; private set; }
    [field: SerializeField, TextArea] public string Description { get; private set; }

    [field: SerializeField] public int Width { get; private set; }
    [field: SerializeField] public int Height { get; private set; }
    [field: SerializeField] public int Rotation { get; set; }

    public Item(ItemInfo itemInfo)
    {
        DisplayName = itemInfo.DisplayName;
        Sprite = itemInfo.Sprite;
        Description = itemInfo.Description;
        Width = itemInfo.Width;
        Height = itemInfo.Height;
        Rotation = 0;
    }
}
