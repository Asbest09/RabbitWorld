using UnityEngine;
using Zenject;

public class PlayerModel : IInitializable
{
    private readonly Vector2Int _startPosition = new Vector2Int(0, 0);
    private Vector2Int _position;
    private int _angle;

    public void Move()
    {
        int angle = Mathf.Abs(_angle);

        if (angle == 0)
            _position += new Vector2Int(1, 0);
        else if (angle == 90)
            _position += new Vector2Int(0, 1);
        else if (angle == 180)
            _position += new Vector2Int(-1, 0);
        else if (angle == 270)
            _position += new Vector2Int(0, -1);

        Debug.Log(_position);
    }

    public void Jump()
    {
        
    }

    public void RotateLeft()
    {
        _angle -= 90;

        if(_angle == -360)
            _angle = 0;
    }

    public void RotateRight()
    {
        _angle += 90;

        if (_angle == 360)
            _angle = 0;
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
