using System;

namespace Assets.Scripts.BasicLogic.Model.Commands
{
    public class Function : Command
    {
        public Action Action { get; set; }

        public void Execute()
        {
        }
    }
}
