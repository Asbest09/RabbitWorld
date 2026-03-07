using System.Collections.Generic;
using Assets.Scripts.BasicLogic.View.Cells;
using Zenject;

namespace Assets.Scripts.BasicLogic.Model
{
    public class Engine
    {
        private PlayerModel _player;

        [Inject]
        private void Constructor(PlayerModel player)
        {
            _player = player;
        }

        public void Execute(List<Cell> cells, List<Cell> functionCell)
        {
            List<Command> functionCommnand = new List<Command>();

            foreach (Cell cell in functionCell)
                functionCommnand.Add(cell.SelfCommand);

            foreach (Cell cell in cells)
            {
                if (cell.SelfCommand != null)
                {
                    if (cell.SelfCommand.Action == null)
                        foreach (Command command in functionCommnand)
                            command?.Execute();
                    else
                        cell.SelfCommand?.Execute();
                }
            }

            _player.LastCommand();
        }
    }
}