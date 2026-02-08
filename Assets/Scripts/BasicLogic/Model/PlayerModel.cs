using Assets.Configs;
using Assets.Scripts.BasicLogic.Service.Data;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.LevelConfig;
using static Assets.Scripts.BasicLogic.Service.Data.Configs.PanelConfig;

public class PlayerModel
{
    public event Action<string> AddToQueue;
    public event Action<Vector2Int> MoveToStartAction;

    private Vector2Int _position;
    private Vector2Int _endPoint;
    private Vector2Int _startPoint;
    private int _angle;
    private List<PanelPosition> _panelPositions;

    [Inject] private void Constructor(StaticDataService staticDataService)
    {
        _endPoint = staticDataService.GetEndPoint();
        _startPoint = staticDataService.GetStartPoint();
        _position = _startPoint;
        _panelPositions = staticDataService.GetPanelPositions();
    }

    public void Move()
    {
        _position += new Vector2Int((int)Mathf.Cos(_angle * Mathf.Deg2Rad), -(int)Mathf.Sin(_angle * Mathf.Deg2Rad));

        foreach (PanelPosition panelPosition in _panelPositions)
        {
            if(panelPosition.Position == _position && panelPosition.Id == Panels.BlockedPanelId)
            {
                AddToQueue?.Invoke(CommandPaths.BlockedCommandId);
                return;
            }
        }

        AddToQueue?.Invoke(CommandPaths.MoveCommandId);
    }

    public void Jump()
    {
        
    }

    public void RotateLeft()
    {
        _angle -= 90;

        AddToQueue?.Invoke(CommandPaths.LeftCommandId);
    }

    public void RotateRight()
    {
        _angle += 90;

        AddToQueue?.Invoke(CommandPaths.RightCommandId);
    }

    public void LastCommand()
    {
        if (_endPoint == _position)
        {
            AddToQueue?.Invoke(CommandPaths.CompletePointId);
        }
    }

    public void MoveToStart()
    {
        _position = _startPoint;
        _angle = 0;

        MoveToStartAction?.Invoke(_position);
    }
}
