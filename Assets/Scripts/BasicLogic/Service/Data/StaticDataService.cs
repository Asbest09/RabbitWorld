using Assets.Configs;
using Assets.Scripts.BasicLogic.Service.Data.Configs;
using Assets.Scripts.BasicLogic.View;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.PanelConfig;

namespace Assets.Scripts.BasicLogic.Service.Data
{
    public class StaticDataService
    {
        private CommandConfig _commandConfig;
        private LevelConfigs _levelConfigs;
        private LevelConfig _levelConfig;
        private PanelConfig _panelConfig;
        private int _currentLevelIndex;

        [Inject]
        private void Constructor()
        {
            _commandConfig = Resources.Load<CommandConfig>("CommandsConfig");
            _levelConfigs = Resources.Load<LevelConfigs>("LevelConfig");
            _panelConfig = Resources.Load<PanelConfig>("PanelConfig");
        }

        public void SetLevelIndex(int index)
        {
            _currentLevelIndex = index;
            _levelConfig = _levelConfigs.Configs[_currentLevelIndex];
        }

        public UIElement GetUIElement() =>
            _commandConfig.UIPrefab;

        public Dictionary<string, CommandSetting> GetCommands() =>
            _commandConfig.CommandSettings.ToDictionary(value => value.Id, value => value);

        public List<string> GetAvailableCommands()
        {
            List<string> commands = new List<string>();

            foreach (Commands s in _levelConfig.AvailableCommands)
            {
                switch (s)
                {
                    case Commands.RightCommandId:
                        commands.Add(CommandPaths.RightCommandId);
                        break;
                    case Commands.LeftCommandId:
                        commands.Add(CommandPaths.LeftCommandId);
                        break;
                    case Commands.MoveCommandId:
                        commands.Add(CommandPaths.MoveCommandId);
                        break;
                }    
            }

            return commands;
        }

        public int GetCellsCount() =>
            _levelConfig.CellsCount;

        public Cell GetCell() =>
            _commandConfig.CellPrefab;

        public Panel GetPanel() =>
            _panelConfig.PanelPrefab;

        public List<PanelPosition> GetPanelPositions() =>
            _levelConfig.PanelPositions;

        public float GetPanelSize() =>
            _panelConfig.PanelSize;

        public Vector2Int GetEndPoint()
        {
            foreach (PanelPosition panelPosition in _levelConfig.PanelPositions)
                if (panelPosition.Id == Panels.EndPanelId)
                    return panelPosition.Position;

            throw new Exception("No end point in level - " + _currentLevelIndex);
        }
            
        public Vector2Int GetStartPoint()
        {
            foreach (PanelPosition panelPosition in _levelConfig.PanelPositions)
                if (panelPosition.Id == Panels.StartPanelId)
                    return panelPosition.Position;

            throw new Exception("No start point in level - " + _currentLevelIndex);
        }

        public Material GetTexture(Panels id)
        {
            foreach (PanelSetting panelSetting in _panelConfig.PanelsTypes)
                if (panelSetting.Id == id)
                    return panelSetting.Texture;

            throw new Exception("Error in panelSettings");
        }

        public int GetCountLevels() =>
            _levelConfigs.Configs.Count();
    }
}