using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    public event Action<Vector2> Dragged;
    public event Action<Vector2> ClickStarted;
    public event Action<Vector2> ClickFinished;
}
