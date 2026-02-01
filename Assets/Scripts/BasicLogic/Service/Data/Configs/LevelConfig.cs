using Assets.Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/level config", order = 51)]
    public class LevelConfig : ScriptableObject
    {
        public List<Season> AvailableCommands;
        public int CellsCount;
        public int CountPanelX;
        public int CountPanelY;
        public Vector2Int EndPoint;

        public enum Season
        {
            MoveCommandId,
            LeftCommandId,
            RightCommandId
        }
    }
}