using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    [SerializeField] GameObject _cellsContainer;

    public override void InstallBindings()
    {
        Container.Bind<PlayerModel>().AsSingle();
        Container.Bind<Engine>().AsSingle();
        Container.Bind<Move>().AsSingle();
        Container.Bind<Jump>().AsSingle();
        Container.Bind<RotateLeft>().AsSingle();
        Container.BindInterfacesTo<InputService>().AsSingle();
        Container.BindInterfacesAndSelfTo<StaticDataService>().AsSingle();
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
        Container.Bind<List<Cell>>().FromInstance(_cellsContainer.GetComponentsInChildren<Cell>().ToList()).AsSingle();
        Container.Bind<StaticDataService>().AsSingle();
        Container.Bind<UIFactory>().AsSingle();

        Container
            .BindFactory<UIElement, Transform, UIElement, UIElement.Factory>()
            .FromFactory<Assets.Scripts.BasicLogic.Service.AssetsManagement.PrefabFactory<UIElement>>();
    }
}
