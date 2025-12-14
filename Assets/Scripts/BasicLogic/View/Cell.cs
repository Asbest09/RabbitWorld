using Assets.Scripts.BasicLogic.View;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Command SelfCommand { get; private set; }

    private UIElement _uIElement;

    public void SetCommand(Command command, UIElement uIElement)
    {
        SelfCommand = command;

        if(_uIElement != null)
            Destroy(_uIElement.gameObject);

        _uIElement = uIElement;
    }
}
