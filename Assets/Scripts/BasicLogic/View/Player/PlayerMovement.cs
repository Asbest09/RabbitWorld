using Assets.Configs;
using Assets.Scripts.BasicLogic.Service.Data;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region events
    public event Action CompleteLevel;
    #endregion

    [SerializeField] private float _moveDuration;
    [SerializeField] private float _rotateDuration;

    private Vector3 _target;
    private StaticDataService _staticDataService;
    private float _panelSize;
    private Queue<string> _commands = new Queue<string>();
    private bool _commandIsExecuting;
    private bool _playerOnStart;
    private PlayerModel _playerModel;

    private void Start()
    {
        _playerOnStart = true;
        _target = transform.position;
        _panelSize = _staticDataService.GetPanelSize();
    }

    private void Update()
    {
        while (_commands.Count > 0 && !_commandIsExecuting && _playerOnStart)
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
                case CommandPaths.BlockedCommandId:
                    Clash();
                    break;
                case CommandPaths.CompletePointId:
                    Complete();
                    break;
            }

            if (_commands.Count == 0)
                _playerOnStart = false;
        }
    }

    public void Init(StaticDataService staticDataService, PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _staticDataService = staticDataService;

        _playerModel.AddToQueue += AddCommand;
        _playerModel.MoveToStartAction += MoveToStart;
    }

    private void OnDisable()
    {
        _playerModel.AddToQueue -= AddCommand;
        _playerModel.MoveToStartAction -= MoveToStart;
    }

    private void AddCommand(string commands)
    {
        if(_playerOnStart && !_commandIsExecuting)
            _commands.Enqueue(commands);
    }
        
    private void Rotate(float angle) => 
        transform.DORotate(transform.eulerAngles + Vector3.up * angle, _rotateDuration).OnComplete(() => _commandIsExecuting = false);

    private void Move() => 
        transform.DOMove(_target, _moveDuration).OnComplete(() => _commandIsExecuting = false);

    private void MoveToStart(Vector2Int spawnPoint)
    {
        if (_commandIsExecuting)
            return;

        Vector3 startPoint = new Vector3(spawnPoint.x * _panelSize, 0 , spawnPoint.y * _panelSize);

        if(_target == startPoint && transform.eulerAngles == Vector3.up * 90) 
            return;

        _target = startPoint;
        _commandIsExecuting = true;
        transform.DORotate(Vector3.up * 90, _rotateDuration).OnComplete(() => transform.DOMove(_target, _moveDuration).OnComplete(() => { _playerOnStart = true; _commandIsExecuting = false; }));
    }

    private void Clash()
    {
        _commands.Clear();

        _target += transform.forward * _panelSize / 2;
        transform.DOMove(_target, _moveDuration / 2).OnComplete(() => { _target -= transform.forward * _panelSize / 2; transform.DOMove(_target, _moveDuration / 2).OnComplete(() => _commandIsExecuting = false) ; });
    }

    private void Complete()
    {
        CompleteLevel?.Invoke();

        _commandIsExecuting = false;
    }
}
