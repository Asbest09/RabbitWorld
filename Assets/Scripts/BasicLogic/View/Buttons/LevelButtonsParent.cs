using UnityEngine;

public class LevelButtonsParent : MonoBehaviour
{
    [SerializeField] private int _countLevels;
    [SerializeField] private LevelButton _buttonPrefab;

    private LevelLoader _loader;

    private void Start()
    {
        for (int i = 0; i < _countLevels; i++)
        {
            LevelButton button = Instantiate(_buttonPrefab);
            button.Init(i, _loader);
        }
    }
    public void Init(LevelLoader loader)
    {
        _loader = loader;
    }
}
