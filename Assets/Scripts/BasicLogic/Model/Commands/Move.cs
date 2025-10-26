using System;

public class Move : Command
{
    public Action Action { get; set; }

    public Move(PlayerModel model)
    {
        Action = model.Move;
    }

    public void Execute()
    {
        Action?.Invoke();
    }
}
