using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CellParent : MonoBehaviour
{
    private StaticDataService _staticDataService;
    private DiContainer _container;
    private Engine _engine;
    private List<Cell> _cells;

    private void Awake()
    {
        SpawnCells();
    }

    public void Init(StaticDataService staticDataService, DiContainer container, Engine engine)
    {
        _staticDataService = staticDataService;
        _container = container;
        _engine = engine;
    }

    public void ExecuteCommands() =>
        _engine.Execute(_cells);

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

        _cells = cells; 
    }
}
