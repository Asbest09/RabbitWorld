using Assets.Configs;
using Assets.Scripts.BasicLogic.View;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.System.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerModel>().AsSingle();
            Container.Bind<Engine>().AsSingle(); 
            Container.Bind<UIFactory>().AsSingle();
            Container.Bind<GameBootstrapper>().FromInstance(gameObject.GetComponent<GameBootstrapper>()).AsSingle();

            Dictionary<string, Command> commandTypes = new Dictionary<string, Command>()
            {
                { CommandPaths.RightCommandId, new RotateRight(Container.Resolve<PlayerModel>()) },
                { CommandPaths.LeftCommandId,  new RotateLeft(Container.Resolve<PlayerModel>()) },
                { CommandPaths.MoveCommandId, new Move(Container.Resolve<PlayerModel>()) }
            };

            Container.Bind<Dictionary<string, Command>>().FromInstance(commandTypes).AsSingle();

            Container
                .BindFactory<UIElement, Transform, UIElement, UIElement.Factory>()
                .FromFactory<BasicLogic.Service.AssetsManagement.PrefabFactory<UIElement>>();

        }
    }
}