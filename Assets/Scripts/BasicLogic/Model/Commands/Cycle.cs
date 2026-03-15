using System;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Model.Commands
{
    public class Cycle : Command
    {
        public Action Action { get; set; }
        public string Type { get; private set; }

        public Cycle(string type)
        {
            Type = type;
        }

        public void Execute()
        {

        }
    }
}