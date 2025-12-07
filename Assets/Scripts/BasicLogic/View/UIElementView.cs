using UnityEngine;
using UnityEngine.UI;

public class UIElementView : MonoBehaviour
{
    private string _id;
    private Image _image;

    public void Setup(string id, Sprite sprite)
    {
        _image = GetComponent<Image>();

        _image.sprite = sprite;
        _id = id;
    }

    public string GetId() =>
        _id;
}
