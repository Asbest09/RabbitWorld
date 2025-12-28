using System.Collections.Generic;

public class Engine
{
    public void Execute(List<Cell> cells)
    {
        foreach (Cell cell in cells)
            cell.SelfCommand?.Execute();
    }
}
