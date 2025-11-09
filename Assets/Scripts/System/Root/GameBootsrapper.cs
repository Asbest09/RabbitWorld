using UnityEngine;
using Zenject;

public class GameBootsrapper : MonoInstaller
{
    [SerializeField] private CellsList _cells;

    public override void InstallBindings()
    {
        Container.Bind<CellsList>().FromInstance(_cells).AsSingle();
    }
}