using System.Collections.Generic;
using Assets.Scripts.BasicLogic.Model;
using Assets.Scripts.BasicLogic.Model.Commands;
using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.Service.InputService;
using Assets.Scripts.BasicLogic.View.Cells;
using UnityEngine;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;

namespace Assets.Scripts.BasicLogic.View
{
    public class UiElementsParent : MonoBehaviour
    {
        private List<UIElement> _elements;
        private UIFactory _factory;
        private UIElement.Factory _uIFactory;
        private StaticDataService _staticDataService;
        private List<Cell> _cells;
        private IInputService _inputService;
        private Dictionary<Commands, Command> _commands;

        private void Awake()
        {
            _elements = new List<UIElement>();
            SpawnStartElements(); 
        }

        private void OnDisable()
        {
            foreach (UIElement uIElement in _elements)
                uIElement.Clicked -= CreateElement;
        }

        public void Init(UIFactory factory, UIElement.Factory uIFactory, StaticDataService staticDataService, IInputService inputService, PlayerModel playerModel)
        {
            _staticDataService = staticDataService;
            _factory = factory;
            _uIFactory = uIFactory;
            _inputService = inputService;

            _commands = new Dictionary<Commands, Command>()
            {
                 { Commands.MoveCommandId, new Move(playerModel) },
                 { Commands.LeftCommandId, new RotateLeft(playerModel) },
                 { Commands.RightCommandId, new RotateRight(playerModel) },
                 { Commands.Function, new Function() }
            };
        }

        public void SetCells(List<Cell> cells)
        {
            _cells = cells;
        }

        private void CreateElement(UIElement element)
        {
            Commands id = element.GetId();
            UIElement uIElement = _factory.Spawn(id, element.gameObject.transform, _uIFactory);

            _elements.Add(uIElement);
            uIElement.SetDragged();
            uIElement.Init(_cells, _inputService, id, _commands[id]);
        }

        private void SpawnStartElements()
        {
            List<Commands> allIds = _staticDataService.GetAvailableCommands();
            Dictionary<Commands, CommandSetting> commands = _staticDataService.GetCommands();
            _cells = new List<Cell>();

            foreach (Commands id in allIds)
            {
                UIElement uIElement = _factory.Spawn(id, transform, _uIFactory);

                _elements.Add(uIElement);
                uIElement.Clicked += CreateElement;
                uIElement.Init(_cells, _inputService, id, _commands[id]);
            }
        }
    }
}