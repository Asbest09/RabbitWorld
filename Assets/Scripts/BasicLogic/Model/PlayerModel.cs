using Assets.Configs;
using Assets.Scripts.BasicLogic.Service.Data;
using System;
using UnityEngine;
using Zenject;

public class PlayerModel
{
    public event Action<string> AddToQueue;
    public event Action<Vector3> MoveToStartAction;

    private readonly Vector2Int _startPosition = new Vector2Int(0, 0);
    private Vector2Int _position;
    private Vector2Int _endPoint;
    private int _angle;

    [Inject] private void Constructor(StaticDataService staticDataService)
    {
        _endPoint = staticDataService.GetEndPoint();
    }

    public void Move()
    {
        _position += new Vector2Int((int)Mathf.Cos(_angle * Mathf.Deg2Rad), -(int)Mathf.Sin(_angle * Mathf.Deg2Rad));

        AddToQueue?.Invoke(CommandPaths.MoveCommandId);
    }

    public void Jump()
    {
        
    }

    public void RotateLeft()
    {
        _angle -= 90;

        AddToQueue?.Invoke(CommandPaths.LeftCommandId);
    }

    public void RotateRight()
    {
        _angle += 90;

        AddToQueue?.Invoke(CommandPaths.RightCommandId);
    }

    public void LastCommand()
    {
        if (_endPoint == _position)
            Debug.Log("Вы прошли уровень!");
    }

    public void MoveToStart()
    {
        _position = _startPosition;
        _angle = 0;

        MoveToStartAction?.Invoke(Vector3.zero);
    }
}
