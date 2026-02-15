using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections.Generic;
using UnityEngine;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.PanelConfig;

public class WorldGenerator : MonoBehaviour
{
    private StaticDataService _staticDataService;
    private Panel _panelPrefab;
    private float _panelSize;

    private void Awake()
    {
        SpawnPanels();
    }

    public void Init(StaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    private void SpawnPanels()
    {
        List<PanelPosition> panels = _staticDataService.GetPanelPositions();
        _panelPrefab = _staticDataService.GetPanel();
        _panelSize = _staticDataService.GetPanelSize();

        foreach(PanelPosition panel in panels)
            Create(GridToWorldPosition(panel.Position), panel.Id);
    }

    private void Create(Vector3 worldPosition, Panels id)
    {
        Panel newPanel = Instantiate(_panelPrefab, worldPosition, Quaternion.identity);
        newPanel.Setup(_staticDataService.GetTexture(id));
    }

    private Vector3 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(
               gridPosition.x * _panelSize,
               transform.position.y,
               gridPosition.y * _panelSize);
    }
}
