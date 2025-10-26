using System;

public class Jump : Command
{
    public Action Action { get; set; }

    public Jump(PlayerModel model)
    {
        Action = model.Jump;
    }

    public void Execute()
    {
        Action?.Invoke();
    }
}
