using System;

namespace Assets.Scripts.BasicLogic.Model
{
    public interface Command
    {
        public Action Action { get; set; }

        public void Execute();
    }
}