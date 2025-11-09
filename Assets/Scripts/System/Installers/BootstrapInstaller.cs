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
        Container.Bind<IInputService>().To<InputService>().AsSingle();
        Container.Bind<Camera>().FromInstance(Camera.main).AsSingle();
    }
}
