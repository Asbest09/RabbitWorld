using Assets.Scripts.BasicLogic.Service.Data;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputService>().AsSingle();
        Container.Bind<StaticDataService>().AsSingle();
    }
}
