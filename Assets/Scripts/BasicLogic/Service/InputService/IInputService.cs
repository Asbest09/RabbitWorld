using System;
using UnityEngine;

namespace Assets.Scripts.BasicLogic.Service.InputService
{
    public interface IInputService
    {
        public event Action<Vector2> Dragged;
        public event Action<Vector2> ClickStarted;
        public event Action<Vector2> ClickFinished;
        public event Action<Vector2> RightClick;
    }
}