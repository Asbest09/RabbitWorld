using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerModel>().AsSingle();
        Container.Bind<Engine>().AsSingle();
        Container.Bind<Move>().AsSingle();
        Container.Bind<Jump>().AsSingle();
        Container.Bind<RotateLeft>().AsSingle();
        Container.BindInterfacesTo<InputService>().AsSingle();
        Container.Bind<StaticDataService>().AsSingle();
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
       // Container.Bind<List<Cell>>().FromInstance().AsSingle();
        Container.Bind<UIFactory>().AsSingle();

        Container
            .BindFactory<UIElement, Transform, UIElement, UIElement.Factory>()
            .FromFactory<Assets.Scripts.BasicLogic.Service.AssetsManagement.PrefabFactory<UIElement>>();
    }
}
