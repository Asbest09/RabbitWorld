using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CellParent : MonoBehaviour
{
    private StaticDataService _staticDataService;
    private DiContainer _container;

    [Inject]
    private void Constructor(StaticDataService staticDataService, DiContainer container)
    {
        _staticDataService = staticDataService;
        _container = container; 
    }

    private void Awake()
    {
        SpawnCells();
    }

    private void SpawnCells()
    {
        int countCells = _staticDataService.GetCellsCount();
        Cell cellPrefab = _staticDataService.GetCell();
        List<Cell> cells = new List<Cell>();

        for (int i = 0; i < countCells; i++)
        {
            Cell cell = Instantiate(cellPrefab, transform);

            cells.Add(cell);
        }

        _container.Bind<List<Cell>>().FromInstance(cells).AsSingle();
    }
}
