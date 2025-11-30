using UnityEngine;
using UnityEngine.UI;

public class UIBuilder : MonoBehaviour
{
    private string _id;
    private Image _image;
    private Command _command;

    public void Setup(Sprite icon, string id, Command command)
    {
        if (_image == null)
            _image = GetComponent<Image>();

        _image.sprite = icon;
        _id = id;
        _command = command;
    }

    public string GetId() =>
        _id;

    public Command GetCommand() => 
        _command;
}
