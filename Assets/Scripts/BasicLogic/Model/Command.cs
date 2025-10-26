using System;

public interface Command
{
    public Action Action { get; set; }

    public void Execute();
}
