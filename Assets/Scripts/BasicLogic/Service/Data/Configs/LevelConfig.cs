using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/level config", order = 51)]
    public class LevelConfig : ScriptableObject
    {
        public List<string> AvailableCommands;
        public int CellsCount;
    }
}