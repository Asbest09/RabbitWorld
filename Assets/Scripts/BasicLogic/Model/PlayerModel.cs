using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public event Action<Queue<Vector2Int>> MoveAction;

    private readonly Vector2Int _startPosition = new Vector2Int(0, 0);
    private Vector2Int _position;
    private int _angle;
    private Queue<Vector2Int> _steps = new Queue<Vector2Int>();

    public void Move()
    {
        Vector2Int step = new Vector2Int((int)Mathf.Cos(_angle * Mathf.PI / 180), -(int)Mathf.Sin(_angle * Mathf.PI / 180));
        _position += step;
        _steps.Enqueue(step);

        MoveAction?.Invoke(_steps);

        Debug.Log(_position);
    }

    public void Jump()
    {
        
    }

    public void RotateLeft()
    {
        _angle -= 90;

        Debug.Log(_angle);
    }

    public void RotateRight()
    {
        _angle += 90;

        Debug.Log(_angle);
    }

    public void MoveToStart()
    {
        _position = _startPosition;
        _angle = 0;
        _steps.Clear();
    }
}
