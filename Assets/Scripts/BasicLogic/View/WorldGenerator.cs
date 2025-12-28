using Assets.Scripts.BasicLogic.Service.Data;
using UnityEngine;
using Zenject;

public class WorldGenerator : MonoBehaviour
{
    private StaticDataService _staticDataService;
    private Panel[,] _panelMap;
    private Panel _panelPrefab;
    private float _panelSize;

    private void Awake()
    {
        SpawnPanels();
    }

    [Inject] private void Constructor(StaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    private void SpawnPanels()
    {
        _panelPrefab = _staticDataService.GetPanel();
        int countPanelsX = _staticDataService.GetCountPanelsX();
        int countPanelsY = _staticDataService.GetCountPanelsY();
        _panelSize = _staticDataService.GetPanelSize();
        _panelMap = new Panel[countPanelsX, countPanelsY];

        for (int i = 0; i < countPanelsX; i++)
        {
            for (int j = 0; j < countPanelsY; j++)
            {
                Create(GridToWorldPosition(new Vector2Int(i, j)));
            }
        }
    }

    private void Create(Vector3 worldPosition)
    {
        Panel newPanel = Instantiate(_panelPrefab, worldPosition, Quaternion.identity);
        _panelMap[(int)newPanel.transform.position.x, (int)newPanel.transform.position.z] = newPanel;
    }

    private Vector3 GridToWorldPosition(Vector2Int gridPosition)
    {
        return new Vector3(
               gridPosition.x * _panelSize,
               transform.position.y,
               gridPosition.y * _panelSize);
    }
}
