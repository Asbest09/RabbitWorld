using Assets.Scripts.BasicLogic.View;
using System;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "CommandConfig", menuName = "Configs/command config", order = 51)]
    public class CommandConfig : ScriptableObject
    {
        public UIElement Prefab;
        public CommandSetting[] CommandSettings;

        [Serializable]
        public class CommandSetting
        {
            public string Id;
            public Sprite Icon;
        }
    }
}