using System;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.PanelConfig;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/level config", order = 51)]
    public class LevelConfig : ScriptableObject
    {
        public List<Commands> AvailableCommands;
        public List<PanelPosition> PanelPositions;
        public int CellsCount;

        public enum Commands
        {
            MoveCommandId,
            LeftCommandId,
            RightCommandId
        }

        [Serializable]
        public class PanelPosition
        {
            public Panels Id;
            public Vector2Int Position;
        }
    }
}