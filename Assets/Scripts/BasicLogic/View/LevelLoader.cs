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
        if(_staticDataService.GetCountLevels() > _staticDataService.GetCurrentLevel() + 1)
        {
            _staticDataService.SetLevelIndex(levelIndex);
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
            _staticDataService.SetLevelIndex(0);
        }    
    }
}
