using System;

public class RotateLeft : Command
{
    public Action Action { get;  set; }

    public RotateLeft(PlayerModel model)
    {
        Action = model.RotateLeft;
    }

    public void Execute()
    {
        Action?.Invoke();
    }
}
