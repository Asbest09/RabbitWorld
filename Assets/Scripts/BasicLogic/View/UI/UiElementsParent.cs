using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.CommandConfig;

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
            _elements = new List<UIElement>();
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
            uIElement.Init(_cells, _inputService, _staticDataService);
        }

        private void SpawnStartElements()
        {
            List<string> allIds = _staticDataService.GetAvailableCommands();
            Dictionary<string, CommandSetting> commands = _staticDataService.GetCommands();
            _cells = new List<Cell>();

            foreach (string id in allIds)
            {
                UIElement uIElement = _factory.Spawn(id, transform, _uIFactory);

                _elements.Add(uIElement);
                uIElement.Clicked += CreateElement;
                uIElement.Init(_cells, _inputService, _staticDataService);
            }
        }
    }
}