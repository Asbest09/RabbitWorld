using UnityEngine;

public class LevelButton : MonoBehaviour
{
    private int _levelIndex;
    private LevelLoader _loader;

    public void Init(int index, LevelLoader loader)
    {
        _levelIndex = index;
        _loader = loader;
    }

    public void OnClick()
    {
        _loader.LoadLevel(_levelIndex);
    }
}
