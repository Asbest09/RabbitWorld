using System.Linq;
using UnityEngine;
using Zenject;

public class CellsList : MonoBehaviour, IInitializable
{
    [Inject] private DiContainer _container;

    public void Initialize()
    {
        Cell[] cells = FindObjectsOfType<Cell>();

        _container.Bind<Cell[]>().FromInstance(cells);
    }
}