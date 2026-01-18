using UnityEngine;
using UnityEngine.UI;

public class UIElementView : MonoBehaviour
{
    [SerializeField] private Image _image;

    private string _id;

    public void Setup(string id, Sprite sprite)
    {
        _image.sprite = sprite;
        _id = id;
    }

    public string GetId() =>
        _id;
}
