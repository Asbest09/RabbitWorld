using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIElement : MonoBehaviour, IDisposable
{
    [Inject] private Camera _camera;
    [Inject] private List<Cell> _cells;
    [Inject] private IInputService _inputService;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Command _command;

    private bool _isDragged;
    private RectTransform[] _cellsTransform;

    public void Dispose()
    {
        _inputService.ClickStarted -= OnClicked;
        _inputService.ClickFinished -= OnClickFinished;
        _inputService.Dragged -= OnDragged;
    }

    private void Start()
    {
        _inputService.ClickStarted += OnClicked;
        _inputService.ClickFinished += OnClickFinished;
        _inputService.Dragged += OnDragged;

        _cellsTransform = new RectTransform[_cells.Count];

        for (int i = 0; i < _cells.Count; i++)
            _cellsTransform[i] = _cells[i].gameObject.GetComponent<RectTransform>();
    }

    private void OnClicked(Vector2 inputPosition)
    {
        _isDragged = RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, new Vector2(inputPosition.x, inputPosition.y));
    }

    private void OnDragged(Vector2 inputPosition)
    {
        if (_isDragged == false)
            return;

        _rectTransform.position = inputPosition;
    }

    private void OnClickFinished(Vector2 inputPosition)
    {
        if (_isDragged == false)
            return;

        _isDragged = false;

        Debug.Log(_cellsTransform.Length);//длиня равна 0 у _cellsTransform

        foreach (RectTransform rect in _cellsTransform)
        {
            if(RectTransformUtility.RectangleContainsScreenPoint(rect, new Vector2(inputPosition.x, inputPosition.y)))
            { 
                rect.gameObject.GetComponent<Cell>().SetCommand(_command);

                transform.position = rect.position;
                break;
            }
        }
    }
}
