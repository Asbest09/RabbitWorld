using Assets.Configs;
using System;
using UnityEngine;

public class PlayerModel
{
    public event Action<string> AddToQueue;

    private readonly Vector2Int _startPosition = new Vector2Int(0, 0);
    private Vector2Int _position;
    private int _angle;

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

    public void MoveToStart()
    {
        _position = _startPosition;
        _angle = 0;
    }
}
