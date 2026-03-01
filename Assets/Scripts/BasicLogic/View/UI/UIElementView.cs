using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;

public class UIElementView : MonoBehaviour
{
    [SerializeField] private Image _image;

    private Commands _id;

    public void Setup(Commands id, Sprite sprite)
    {
        _image.sprite = sprite;
        _id = id;
    }

    public Commands GetId() =>
        _id;
}
