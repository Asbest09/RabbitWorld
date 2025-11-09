using System;
using UnityEngine;
using Zenject;

public class InputService : IInputService, ITickable
{
    public event Action<Vector2> Dragged;
    public event Action<Vector2> ClickStarted;
    public event Action<Vector2> ClickFinished;

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            ClickStarted?.Invoke(Input.mousePosition);

        if (Input.GetMouseButtonUp(0))
            ClickFinished?.Invoke(Input.mousePosition);

        Dragged?.Invoke(Input.mousePosition);
    }
}
