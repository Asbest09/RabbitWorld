using Assets.Scripts.BasicLogic.View;
using System;
using UnityEngine;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "CommandConfig", menuName = "Configs/command config", order = 51)]
    public class CommandConfig : ScriptableObject
    {
        public UIElement UIPrefab;
        public Cell CellPrefab;
        public CommandSetting[] CommandSettings;

        [Serializable]
        public class CommandSetting
        {
            public Commands Id;
            public Sprite Icon;
        }
    }
}