using UnityEngine;

public class StopButton : MonoBehaviour
{
    private PlayerModel _playerModel;

    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void OnClick()
    {
        _playerModel.MoveToStart();
    }
}