using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIFactory
    {
        private StaticDataService _staticDataService;

        [Inject] private void Constructor(StaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public void Spawn(string Id, Transform transform, UIElement.Factory factory)
        {
            UIElement uIElement = factory.Create(_staticDataService.GetUIElement(), transform);
            uIElement.gameObject.GetComponent<UIElementView>().Setup(Id, _staticDataService.GetCommands()[Id].Icon);
        }
    }
}   