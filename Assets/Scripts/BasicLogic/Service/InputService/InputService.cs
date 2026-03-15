using System;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.Service.InputService
{
    public class InputService : IInputService, ITickable
    {
        public event Action<Vector2> Dragged;
        public event Action<Vector2> ClickStarted;
        public event Action<Vector2> ClickFinished;
        public event Action<Vector2> RightClick;

        public void Tick()
        {
            if (Input.GetMouseButtonDown(0))
                ClickStarted?.Invoke(Input.mousePosition);

            if (Input.GetMouseButtonUp(0))
                ClickFinished?.Invoke(Input.mousePosition);

            if (Input.GetMouseButtonDown(1))
                RightClick?.Invoke(Input.mousePosition);

            Dragged?.Invoke(Input.mousePosition);
        }
    }
}