using System.Collections.Generic;
using Assets.Configs;
using Assets.Scripts.BasicLogic.Model.Commands;
using Assets.Scripts.BasicLogic.View.Cells;
using UnityEngine;
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
            if(!Check(cells))
            {
                Debug.Log("Неправильное написание циклов");
                return;
            }

            List<Command> functionCommnand = new List<Command>();

            foreach (Cell cell in functionCell)
                functionCommnand.Add(cell.SelfCommand);

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].SelfCommand != null)
                {
                    if(cells[i].SelfCommand.GetType() == typeof(Cycle))
                    {
                        int endIndex = GetCycleEnd(cells, i);

                        Debug.Log(i);
                        Debug.Log(endIndex);//проблема с GetRange, при i = 2 и endIndex = 4, count = 3
                        RunCycle(cells.GetRange(i + 1, endIndex - 1), cells[i].GetCountRepeats());//добавить количество повторов в cycle
                        i = endIndex;
                    }
                    else if (cells[i].SelfCommand.Action == null)
                        foreach (Command command in functionCommnand)
                            command?.Execute();
                    else
                        cells[i].SelfCommand?.Execute();
                }
            }

            _player.LastCommand();
        }

        private bool Check(List<Cell> cells)
        {
            int countOpen = 0;
            int countClose = 0;
            int deep = 0;

            foreach (Cell cell in cells)
            {
                if(cell.SelfCommand != null && cell.SelfCommand.GetType() == typeof(Cycle))
                {
                    Cycle cycle = (Cycle)cell.SelfCommand;

                    if (cycle.Type == CommandPaths.StartCycle)
                    {
                        deep++;
                        countOpen++;
                    } 
                    else
                    {
                        deep--;
                        countClose++;
                    }

                    if (deep < 0 || deep > 1)
                        return false;
                }
            }

            return countOpen == countClose;
        }

        private int GetCycleEnd(List<Cell> cells, int index)
        {
            int endIndex = 0;

            for(int i = index; i < cells.Count; i++)
            {
                if (cells[i].SelfCommand != null && cells[i].SelfCommand.GetType() == typeof(Cycle))
                {
                    Cycle cycle = (Cycle)cells[i].SelfCommand;

                    if(cycle.Type == CommandPaths.EndCycle)
                    {
                        endIndex = i;
                        break;
                    }
                }
            }

            return endIndex;
        }

        private void RunCycle(List<Cell> cells, int countRepeats)
        {
            Debug.Log(cells.Count);

            for (int i = 0; i < cells.Count; i++)
                Debug.Log(cells[i].SelfCommand);

            for (int i = 0; i < countRepeats; i++)
                for (int j = 0; j < cells.Count; j++)
                    cells[j].SelfCommand?.Execute();
        }
    }
}