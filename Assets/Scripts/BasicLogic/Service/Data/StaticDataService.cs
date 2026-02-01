using Assets.Scripts.BasicLogic.Service.Data.Configs;
using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;
using Assets.Configs;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;

namespace Assets.Scripts.BasicLogic.Service.Data
{
    public class StaticDataService
    {
        private CommandConfig _commandConfig;
        private LevelConfig _levelConfig;
        private PanelConfig _panelConfig;
        private Dictionary<string, Command> _commandTypes;
        private DiContainer _container;

        [Inject]
        private void Constructor(DiContainer container)
        {
            _container = container;

            _commandConfig = Resources.Load<CommandConfig>("CommandsConfig");
            _levelConfig = Resources.Load<LevelConfig>("LevelConfig");
            _panelConfig = Resources.Load<PanelConfig>("PanelConfig");

            _commandTypes = new Dictionary<string, Command>()
            {
                { CommandPaths.RightCommandId, _container.Resolve<RotateRight>() },
                { CommandPaths.LeftCommandId, _container.Resolve<RotateLeft>() },
                { CommandPaths.MoveCommandId, _container.Resolve<Move>() }
            };
        }

        public UIElement GetUIElement() =>
            _commandConfig.UIPrefab;

        public Dictionary<string, CommandSetting> GetCommands() =>
            _commandConfig.CommandSettings.ToDictionary(value => value.Id, value => value);

        public List<string> GetAvailableCommands()
        {
            List<string> commands = new List<string>();

            foreach (Season s in _levelConfig.AvailableCommands)
            {
                switch (s)
                {
                    case Season.RightCommandId:
                        commands.Add(CommandPaths.RightCommandId);
                        break;
                    case Season.LeftCommandId:
                        commands.Add(CommandPaths.LeftCommandId);
                        break;
                    case Season.MoveCommandId:
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

        public Command GetCommand(string id) =>
            _commandTypes[id];

        public Panel GetPanel() =>
            _panelConfig.PanelPrefab;

        public int GetCountPanelsX() =>
            _levelConfig.CountPanelX;

        public int GetCountPanelsY() =>
            _levelConfig.CountPanelY;

        public float GetPanelSize() =>
            _panelConfig.PanelSize;

        public Vector2Int GetEndPoint() =>
            _levelConfig.EndPoint;
    }
}