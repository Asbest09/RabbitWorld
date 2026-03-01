using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.PanelConfig;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "LevelConfigs", menuName = "Configs/level configs", order = 51)]
    public class LevelConfigs : ScriptableObject
    {
        public List<LevelConfig> Configs;
    }
    
    [Serializable]
    public class LevelConfig
    {
        public List<Commands> AvailableCommands;
        public List<PanelPosition> PanelPositions;
        public int CellsCount;
        public int FunctionCellsCount;

        public enum Commands
        {
            MoveCommandId,
            LeftCommandId,
            RightCommandId,
            Function
        }

        [Serializable]
        public class PanelPosition
        {
            public Panels Id;
            public Vector2Int Position;
        }
    }
}