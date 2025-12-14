using UnityEngine;
using Zenject;

public class CellParent : MonoBehaviour
{
    private StaticDataService _staticDataService;

    [Inject]
    private void Constructor(StaticDataService staticDataService)
    {
        _staticDataService = staticDataService;

        SpawnCells();
    }

    private void Awake()
    {
        //проблемы с регистрацией клеток, она происходит до их спавна
    }

    private void SpawnCells()
    {
        int countCells = _staticDataService.GetCellsCount();
        Cell cell = _staticDataService.GetCell();

        for (int i = 0; i < countCells; i++)
            Instantiate(cell, transform);
    }
}
