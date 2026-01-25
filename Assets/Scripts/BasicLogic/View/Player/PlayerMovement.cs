using Assets.Configs;
using Assets.Scripts.BasicLogic.Service.Data;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotateDuration;

    private Vector3 _target;
    private StaticDataService _staticDataService;
    private float _panelSize;
    private Queue<string> _commands = new Queue<string>();
    private bool _commandIsExecuting;

    private void Start()
    {
        _target = transform.position;
        _panelSize = _staticDataService.GetPanelSize();
    }

    private void Update()
    {
        while (_commands.Count > 0 && !_commandIsExecuting)
        {
            string command = _commands.Dequeue();
            _commandIsExecuting = true;

            switch (command)
            {
                case CommandPaths.MoveCommandId:
                    _target += transform.forward * _panelSize;
                    Move();
                    break;
                case CommandPaths.LeftCommandId:
                    Rotate(-90);
                    break;
                case CommandPaths.RightCommandId:
                    Rotate(90);
                    break;
            }
        }
    }

    public void Init(StaticDataService staticDataService, PlayerModel playerModel)
    {
        _staticDataService = staticDataService;
        playerModel.AddToQueue += AddCommand;
    }

    private void AddCommand(string commands)
    {
        _commands.Enqueue(commands);
    }

    private void Rotate(float angle)
    {
        transform.DORotate(new Vector3(0, transform.rotation.y + angle, 0), _rotateDuration).OnComplete(() => _commandIsExecuting = false);
        //проблема в повороте
    }

    private void Move() => 
        transform.DOMove(_target, _moveDuration).OnComplete(() => _commandIsExecuting = false);
}
