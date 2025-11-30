using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIFactory
    {
        private readonly UIElement _uiElementPrefab;

        public UIFactory(string name, Transform transform, UIElement.Factory factory)
        {
            _uiElementPrefab = Resources.Load<GameObject>(name).GetComponent<UIElement>();

            UIElement uIElement = factory.Create(_uiElementPrefab, transform);
        }
    }

    public class StaticDataServicea
    {
        private Dictionary<int, TestElement> Dic;
        public TestElement value {get; private set;}

        public void Init()
        {
            Test test = new();

            Dic = test.elements.ToDictionary(value => value.id, value => value);
        }

        public TestElement GetEl(int id)
        {
            return Dic[id];
        }
    }
    public class Test : ScriptableObject
    {
        public List<TestElement> elements;
    }

    [Serializable]
    public class TestElement
    {
        public int id;
    }
}