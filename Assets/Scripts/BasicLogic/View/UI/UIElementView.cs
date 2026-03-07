using UnityEngine;
using UnityEngine.UI;

public class UIElementView : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void Setup(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
