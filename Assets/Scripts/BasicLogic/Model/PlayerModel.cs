using UnityEngine;
using Zenject;

public class PlayerModel : IInitializable
{
    private readonly Vector2Int _startPosition = new Vector2Int(0, 0);
    private Vector2Int _position;
    private int _angle;

    public void Move()
    {
        _position += new Vector2Int((int)Mathf.Cos(_angle), (int)Mathf.Sin(_angle));

        Debug.Log(_position);
    }

    public void Jump()
    {
        
    }

    public void RotateLeft()
    {
        _angle -= 90;
    }

    public void RotateRight()
    {
        _angle += 90;
    }

    public void MoveToStart()
    {
        _position = _startPosition;
    }

    public void Initialize()
    {
        _position = new Vector2Int(0, 0);
    }
}
