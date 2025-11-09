using System;
using UnityEngine;
using Zenject;

public class UIElement : MonoBehaviour, IDisposable
{
    [Inject] private Camera _camera;
    [Inject] private Cell[] _cells;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Command _command;

    private bool _isDragged;
    private IInputService _inputService;
    private RectTransform[] _cellsTransform;

    public void Dispose()
    {
        _inputService.ClickStarted -= OnClicked;
        _inputService.ClickFinished -= OnClickFinished;
        _inputService.Dragged -= OnDragged;
    }

    [Inject]
    private void Construct(IInputService inputService)
    {
        _inputService = inputService;

        for(int i = 0; i < _cells.Length; i++)
            _cellsTransform[i] = _cells[i].gameObject.GetComponent<RectTransform>();
    }

    private void Start()
    {
        _inputService.ClickStarted += OnClicked;
        _inputService.ClickFinished += OnClickFinished;
        _inputService.Dragged += OnDragged;
    }

    private void OnClicked(Vector2 inputPosition)
    {
        var screenPosition = _camera.WorldToScreenPoint(new Vector3(inputPosition.x, inputPosition.y, 1));

        _isDragged = RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, new Vector2(screenPosition.x, screenPosition.y));
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

        foreach(RectTransform rect in _cellsTransform)
        {
            if(rect.position == new Vector3(inputPosition.x, inputPosition.y, 1))
            {
                rect.gameObject.GetComponent<Cell>().SetCommand(_command);
                break;
            }
        }
    }
}
