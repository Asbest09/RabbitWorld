using UnityEngine;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIFactory
    {
        private readonly UIElement _uiElementPrefab;
        private readonly UIElement.Factory _uiElementFactory;//надо передать factory из UIElement

        public UIFactory(string name, Transform transform)
        {
            _uiElementPrefab = Resources.Load<GameObject>(name).GetComponent<UIElement>();

            UIElement uIElement = _uiElementFactory.Create(_uiElementPrefab, transform);
        }
    }
}