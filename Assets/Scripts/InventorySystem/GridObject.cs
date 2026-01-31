using UnityEngine;
using UnityEngine.UI;

public class GridObject : MonoBehaviour
{
    private Image _image;
    private RectTransform _rectTransform;

    public void SetObject(ItemInfo itemInfo)
    {
        _image = GetComponent<Image>();
        _rectTransform = GetComponent<RectTransform>();
        
        _image.sprite = itemInfo.Sprite;
        _rectTransform.sizeDelta = new Vector2(itemInfo.Width * 100, itemInfo.Height * 100);
        _rectTransform.pivot = new Vector2(1.0f - (0.5f / itemInfo.Width), 1.0f - (0.5f / itemInfo.Height));
    }
}
