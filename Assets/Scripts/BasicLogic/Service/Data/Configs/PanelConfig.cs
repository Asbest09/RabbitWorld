using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Service.Data.Configs
{
    [CreateAssetMenu(fileName = "PanelConfig", menuName = "Configs/Panel config", order = 51)]
    public class PanelConfig : ScriptableObject
    {
        public List<PanelSetting> PanelsTypes;
        public Panel PanelPrefab;
        public float PanelSize;

        [Serializable]
        public class PanelSetting
        {
            public string Id;
            public Texture Texture;
        }
    }
}