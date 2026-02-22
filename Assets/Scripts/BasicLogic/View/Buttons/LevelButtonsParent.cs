using UnityEngine;

public class LevelButtonsParent : MonoBehaviour
{
    [SerializeField] private LevelButton _buttonPrefab;

    private LevelLoader _loader;
    private int _countLevels;

    private void Start()
    {
        for (int i = 0; i < _countLevels; i++)
        {
            LevelButton button = Instantiate(_buttonPrefab, transform);
            button.Init(i, _loader); 
        }
    }

    public void Init(LevelLoader loader, int countLevels)
    {
        _loader = loader;
        _countLevels = countLevels;
    }
}
