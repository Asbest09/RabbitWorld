using Zenject;

public class MainMenuIntaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LevelLoader>().AsSingle();
    }
}
