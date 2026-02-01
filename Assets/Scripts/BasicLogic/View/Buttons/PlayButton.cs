using UnityEngine;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private CellParent _cellParent;

    public void OnClick()
    {
        _cellParent.ExecuteCommands();
    }
}
