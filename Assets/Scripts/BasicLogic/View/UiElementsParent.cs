using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View
{
    public class UiElementsParent : MonoBehaviour
    {
        private List<UIElement> _elements;
        private UIFactory _factory;
        private UIElement.Factory _uIFactory;

        [Inject] private void Constructor(UIFactory factory, UIElement.Factory uIFactory)
        {
            _factory = factory;
        }

        private void OnEnable()
        {
            foreach (UIElement uIElement in _elements)
                uIElement.Clicked += OnUiElementClicked;
        }

        private void OnDisable()
        {
            foreach (UIElement uIElement in _elements)
                uIElement.Clicked -= OnUiElementClicked;
        }

        private void OnUiElementClicked(UIElement element)
        {
            _factory.Spawn(element.gameObject.GetComponent<UIElementView>().GetId(), element.gameObject.transform, _uIFactory);
        }
    }
}