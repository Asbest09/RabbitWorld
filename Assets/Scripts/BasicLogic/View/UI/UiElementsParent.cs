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

        [Inject]
        private void Constructor(UIFactory factory, UIElement.Factory uIFactory, StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _factory = factory;
            _uIFactory = uIFactory;
            _elements = new List<UIElement>();
        }

        private void Awake()
        {
            SpawnStartElements(); 
        }

        private void OnDisable()
        {
            foreach (UIElement uIElement in _elements)
                uIElement.Clicked -= CreateElement;
        }

        private void CreateElement(UIElement element)
        {
            UIElement uIElement = _factory.Spawn(element.gameObject.GetComponent<UIElementView>().GetId(), element.gameObject.transform, _uIFactory);

            _elements.Add(uIElement);
            uIElement.SetDragged();
        }

        private void SpawnStartElements()
        {
            List<string> allIds = _staticDataService.GetAvailableCommands();
            Dictionary<string, CommandSetting> commands = _staticDataService.GetCommands();

            foreach(string id in allIds)
            {
                UIElement uIElement = _factory.Spawn(id, transform, _uIFactory);

                _elements.Add(uIElement);
                uIElement.Clicked += CreateElement;
            }
        }
    }
}