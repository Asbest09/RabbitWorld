using Assets.Scripts.BasicLogic.Service.Data.Configs;
using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;

public class StaticDataService
{
    private CommandConfig _commandConfig;
    private LevelConfig _levelConfig;
    private Dictionary<string, CommandSetting> _commands;
    private UIElement _uIPrefab;
    private Cell _cellPrefab;
    private List<string> _availableCommands;
    private int _cellsCount;

    [Inject]
    private void Constructor()
    {
        _commandConfig = Resources.Load<CommandConfig>("CommandsConfig");
        _levelConfig = Resources.Load<LevelConfig>("LevelConfig");

        _commands = _commandConfig.CommandSettings.ToDictionary(value => value.Id, value => value);
        _uIPrefab = _commandConfig.UIPrefab;
        _cellPrefab = _commandConfig.CellPrefab;
        _availableCommands = _levelConfig.AvailableCommands;
        _cellsCount = _levelConfig.CellsCount;
    }

    public UIElement GetUIElement() =>
        _uIPrefab;

    public Dictionary<string, CommandSetting> GetCommands() =>
        _commands;

    public List<string> GetAvailableCommands() =>
        _availableCommands;

    public int GetCellsCount() => 
        _cellsCount;

    public Cell GetCell() =>
        _cellPrefab;
}
