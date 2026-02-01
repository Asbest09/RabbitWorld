using System.Collections.Generic;
using Zenject;

public class Engine
{
    private PlayerModel _player;

    [Inject] private void Constructor(PlayerModel player)
    {
        _player = player;   
    }

    public void Execute(List<Cell> cells)
    {
        foreach (Cell cell in cells)
            cell.SelfCommand?.Execute();

        _player.LastCommand();
    }
}
