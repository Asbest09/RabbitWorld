using UnityEngine;

public class Cell : MonoBehaviour
{
    public Command SelfCommand { get; private set; }

    public void SetCommand(Command command)
    {
        SelfCommand = command;
    }
}
