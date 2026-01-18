using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.View;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.System.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<Engine>().AsSingle();
            Container.Bind<Move>().AsSingle();
            Container.Bind<Jump>().AsSingle();
            Container.Bind<RotateLeft>().AsSingle();
            Container.Bind<RotateRight>().AsSingle();
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.Bind<StaticDataService>().AsSingle();
            Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
            Container.Bind<UIFactory>().AsSingle();
            Container.Bind<GameBootsrapper>().FromInstance(gameObject.GetComponent<GameBootsrapper>()).AsSingle();
           

            Container
                .BindFactory<UIElement, Transform, UIElement, UIElement.Factory>()
                .FromFactory<BasicLogic.Service.AssetsManagement.PrefabFactory<UIElement>>();
        }
    }
}