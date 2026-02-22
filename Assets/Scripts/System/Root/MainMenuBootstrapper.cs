using Assets.Scripts.BasicLogic.Service.Data;
using UnityEngine;
using Zenject;

public class MainMenuBootstrapper : MonoBehaviour
{
    [SerializeField] private LevelButtonsParent _levelButtonsParent;

    private LevelLoader _levelLoader;
    private StaticDataService _staticDataService;

    [Inject] 
    private void Constructor(LevelLoader levelLoader, StaticDataService staticDataService)
    {
        _levelLoader = levelLoader;
        _staticDataService = staticDataService;
    }

    private void Awake()
    {
        _levelButtonsParent.Init(_levelLoader, _staticDataService.GetCountLevels());
    }
}
