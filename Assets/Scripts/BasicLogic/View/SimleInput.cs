using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SimleInput : MonoBehaviour
{
    private List<Command> _commands;
    [Inject] private PlayerModel _model;
    [Inject] private Engine _inputService;

    public event Action<int> Moved;

    private void Start()
    {
        _commands = new List<Command>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Moved?.Invoke(1);
        }

        if (Input.GetKeyDown(KeyCode.W))
            _commands.Add(new Move(_model));

        if (Input.GetKeyDown(KeyCode.A))
            _commands.Add(new RotateLeft(_model));

        if (Input.GetKeyDown(KeyCode.D))
            _commands.Add(new RotateRight(_model));

        if(Input.GetKeyDown(KeyCode.E))
        {
            _inputService.Execute(_commands);
            _commands.Clear();
        }
    }
}
