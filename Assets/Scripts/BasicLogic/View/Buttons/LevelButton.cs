using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private int _levelIndex;
    private LevelLoader _loader;

    public void Init(int index, LevelLoader loader)
    {
        _levelIndex = index;
        _loader = loader;

        Text text = GetComponentInChildren<Text>();
        text.text += (index + 1);
    }

    public void OnClick()
    {
        _loader.LoadLevel(_levelIndex);
    }
}
