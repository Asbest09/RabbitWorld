using System;
using System.Collections.Generic;

public class Engine
{
    public void Execute(List<Command> commands)
    {
        foreach (Command command in commands)
            command.Execute();
    }
}
