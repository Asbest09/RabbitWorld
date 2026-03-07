using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.Service.InputService;
using Assets.Scripts.BasicLogic.View;
using Zenject;

namespace Assets.Scripts.System.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<InputService>().AsSingle();
            Container.Bind<StaticDataService>().AsSingle();
            Container.Bind<LevelLoader>().AsSingle();
        }
    }
}