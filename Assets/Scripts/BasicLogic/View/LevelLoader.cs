using Assets.Scripts.BasicLogic.Service.Data;
using UnityEngine.SceneManagement;
using Zenject;

public class LevelLoader
{
    private StaticDataService _staticDataService;

    [Inject] private void Constructor(StaticDataService staticDataService)
    {
        _staticDataService = staticDataService;
    }

    public void LoadLevel(int levelIndex)
    {
        _staticDataService.SetLevelIndex(levelIndex);
        SceneManager.LoadScene(2);
    }
}
