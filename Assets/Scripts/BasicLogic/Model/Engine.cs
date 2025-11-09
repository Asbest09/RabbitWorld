using System;
using System.Collections.Generic;

public class Engine
{
    private Dictionary<string, Action> _commands;

    public Engine()
    { 
        _commands = new Dictionary<string, Action>();
    }

    internal void Execute(List<Command> commands)
    {
        foreach (Command command in commands)
            command.Execute();
    }
}
