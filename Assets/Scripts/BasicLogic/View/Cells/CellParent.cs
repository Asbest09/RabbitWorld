using System.Collections.Generic;
using Assets.Scripts.BasicLogic.Model;
using Assets.Scripts.BasicLogic.Service.Data;
using MPUIKIT;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View.Cells
{
    public class CellParent : MonoBehaviour
    {
        [SerializeField] private GameObject _functionParent;

        private StaticDataService _staticDataService;
        private DiContainer _container;
        private Engine _engine;
        private List<Cell> _mainCells;
        private List<Cell> _functionCells;
        private List<Cell> _cells;
        private Cell _cellPrefab;
        private int _functionCountRepeats;

        private void Awake()
        {
            _cells = new List<Cell>();
            _mainCells = new List<Cell>();
            _functionCells = new List<Cell>();

            SpawnCells();
            SpawnFunctionCells();

            _container.Bind<List<Cell>>().FromInstance(_cells).AsSingle();
        }

        public void Init(StaticDataService staticDataService, DiContainer container, Engine engine)
        {
            _staticDataService = staticDataService;
            _container = container;
            _engine = engine;
        }

        public void ExecuteCommands() =>
            _engine.Execute(_mainCells, _functionCells);

        private void SpawnCells()
        {
            int countCells = _staticDataService.GetCellsCount();
            _cellPrefab = _staticDataService.GetCell();
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < countCells; i++)
            {
                Cell cell = Instantiate(_cellPrefab, transform);

                cells.Add(cell);
            }

            _mainCells = cells;
            _cells.AddRange(_mainCells);
        }

        private void SpawnFunctionCells()
        {
            int countCells = _staticDataService.GetFunctionSize();

            if (countCells == 0)
                return;

            _functionParent.GetComponent<MPImage>().enabled = true;
            List<Cell> cells = new List<Cell>();

            for (int i = 0; i < countCells; i++)
            {
                Cell cell = Instantiate(_cellPrefab, _functionParent.transform);

                cells.Add(cell);
            }

            _functionCells = cells;
            _cells.AddRange(_functionCells);
        }
    }
}