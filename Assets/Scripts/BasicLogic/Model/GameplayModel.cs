using System.Collections.Generic;

public class GameplayModel
{
    private readonly Engine _engine;

    public GameplayModel(Engine engine)
    {
        _engine = engine;
    }

    /*public void StartMove(List<Command> commands)
    {
        _engine.Execute(commands);
    }*/

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
