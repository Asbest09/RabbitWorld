using Assets.Scripts.BasicLogic.Service.Data.Configs;
using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;

public class StaticDataService : IInitializable
{
    private CommandConfig _commandConfig;
    private Dictionary<string, CommandSetting> _commands;
    private UIElement _uIPrefab;

    public void Initialize()
    {
        _commandConfig = Resources.Load<CommandConfig>("CommandConfig");

        _commands = _commandConfig.CommandSettings.ToDictionary(value => value.Id, value => value);
        _uIPrefab = _commandConfig.Prefab;
    }

    public UIElement GetUIElement() =>
        _uIPrefab;

    public Dictionary<string, CommandSetting> GetCommands() =>
        _commands;
}
