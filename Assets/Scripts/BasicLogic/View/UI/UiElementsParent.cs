using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections.Generic;
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

        public void Init(UIFactory factory, UIElement.Factory uIFactory, StaticDataService staticDataService, IInputService inputService)
        {
            _staticDataService = staticDataService;
            _factory = factory;
            _uIFactory = uIFactory;
            _inputService = inputService;
        }

        public void GetCells(List<Cell> cells)
        {
            _cells = cells;
        }

        private void CreateElement(UIElement element)
        {
            UIElement uIElement = _factory.Spawn(element.gameObject.GetComponent<UIElementView>().GetId(), element.gameObject.transform, _uIFactory);

            _elements.Add(uIElement);
            uIElement.SetDragged();
            uIElement.Init(_cells, _inputService);
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
                uIElement.Init(_cells, _inputService);
            }
        }
    }
}