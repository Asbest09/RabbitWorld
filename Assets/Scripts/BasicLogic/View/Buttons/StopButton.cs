using System;
using UnityEngine;

public class StopButton : MonoBehaviour
{
    public event Action Close;

    private PlayerModel _playerModel;

    public void Init(PlayerModel playerModel)
    {
        _playerModel = playerModel;
    }

    public void OnClick()
    {
        _playerModel.MoveToStart();
        Close?.Invoke();
    }
}