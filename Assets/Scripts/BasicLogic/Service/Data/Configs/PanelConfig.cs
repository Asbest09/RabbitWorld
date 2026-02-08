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
            public Panels Id;
            public Material Texture;
        }

        public enum Panels
        {
            FreePanelId,
            BlockedPanelId,
            StartPanelId,
            EndPanelId
        }
    }
}