using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.View;
using Assets.Scripts.BasicLogic.View.Buttons;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.System.Root
{
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
}