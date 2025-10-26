using UnityEngine;

public class PlayerModel
{
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
}

public class GameplayModel
{
    private readonly Engine _engine;
    

    public GameplayModel(Engine engine)
    {
        _engine = engine;
    }

    public void Start(Command[] commands)
    {
        _engine.Execute(commands);
    }

    public void OnFailed()
    {
        //_поле.Refresh();
        //_player.MoveToStart();
    }

    public void OnSucssesful()
    {
        //MoveToNextScene();
    }
}
