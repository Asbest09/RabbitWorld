using System;

namespace Assets.Scripts.BasicLogic.Model.Commands
{
    public class RotateRight : Command
    {
        public Action Action { get; set; }

        public RotateRight(PlayerModel model)
        {
            Action = model.RotateRight;
        }

        public void Execute()
        {
            Action?.Invoke();
        }
    }
}