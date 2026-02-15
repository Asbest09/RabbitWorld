using Assets.Scripts.BasicLogic.Service.Data;
using Zenject;

public class ProjectInstaller : MonoInstaller//root 
{
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputService>().AsSingle();
        Container.Bind<StaticDataService>().AsSingle();
        Container.Bind<LevelLoader>().AsSingle();
    }
}
