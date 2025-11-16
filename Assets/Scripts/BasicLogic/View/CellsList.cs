using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class CellsList : MonoBehaviour
{
    [Inject] private DiContainer _container;
    private List<Cell> _cells = new List<Cell>();

    private void Start()
    {
        _cells = FindObjectsOfType<Cell>().ToList();

        _container.Bind<List<Cell>>().FromInstance(_cells);
    }
}