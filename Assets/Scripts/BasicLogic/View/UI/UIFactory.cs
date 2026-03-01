using Assets.Scripts.BasicLogic.Service.Data;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIFactory
    {
        private StaticDataService _staticDataService;

        [Inject] private void Constructor(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public UIElement Spawn(Commands id, Transform transform, UIElement.Factory factory)
        {
            UIElement uIElement = factory.Create(_staticDataService.GetUIElement(), transform);
            uIElement.gameObject.GetComponent<UIElementView>().Setup(id, _staticDataService.GetCommands()[id].Icon);
            return uIElement;
        }
    }
}   