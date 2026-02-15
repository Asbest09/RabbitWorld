using UnityEngine;
using Zenject;

public class MainMenuBootstrapper : MonoBehaviour
{
    [SerializeField] private LevelButtonsParent _levelButtonsParent;

    private LevelLoader _levelLoader;

    [Inject] 
    private void Constructor(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;
    }

    private void Awake()
    {
        Debug.Log(_levelLoader == null);

        _levelButtonsParent.Init(_levelLoader);
    }
}
