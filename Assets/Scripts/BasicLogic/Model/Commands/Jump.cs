using System;

namespace Assets.Scripts.BasicLogic.Model.Commands
{
    public class Jump : Command
    {
        public Action Action { get; set; }

        public Jump(PlayerModel model)
        {
            Action = model.Jump;
        }

        public void Execute()
        {
            Action?.Invoke();
        }
    }
}