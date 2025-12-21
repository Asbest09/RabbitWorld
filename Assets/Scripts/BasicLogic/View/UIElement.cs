using Assets.Scripts.BasicLogic.Service.Data;
using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIElement : MonoBehaviour
    {
        public event Action<UIElement> Clicked;
        
        [SerializeField] private RectTransform _rectTransform;//дальше работать с engine, ui сидят в cell, а cell имеют command

        private Command _command;
        private List<Cell> _cells;
        private IInputService _inputService;
        private bool _isDragged;
        private RectTransform[] _cellsTransform;
        private float _destroyDuration = 1f;
        private Cell _cell;
        private StaticDataService _dataService;

        [Inject]
        private void Construct(List<Cell> cells, IInputService inputService, StaticDataService staticDataService)
        {
            _cells = cells;
            _inputService = inputService;
            _dataService = staticDataService;
        }

        private void Start()
        {
            _inputService.ClickStarted += OnClicked;
            _inputService.ClickFinished += OnClickFinished;
            _inputService.Dragged += OnDragged;

            _cellsTransform = new RectTransform[_cells.Count];
            _command = _dataService.GetCommand(gameObject.GetComponent<UIElementView>().GetId());

            for (int i = 0; i < _cells.Count; i++)
                _cellsTransform[i] = _cells[i].gameObject.GetComponent<RectTransform>();
        }

        private void OnDisable()
        {
            _inputService.ClickStarted -= OnClicked;
            _inputService.ClickFinished -= OnClickFinished;
            _inputService.Dragged -= OnDragged;
        }

        public void SetDragged() => 
            _isDragged = true;

        private void OnClicked(Vector2 inputPosition)
        {
            _isDragged = RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, new Vector2(inputPosition.x, inputPosition.y));

            if (_isDragged && Clicked != null)
            {
                _isDragged = false;

                Clicked?.Invoke(this);
            }
        }

        private void OnDragged(Vector2 inputPosition)
        {
            if (_isDragged == false)
                return;

            if(_cell != null)
            {
                _cell.DeleteElement();

                _cell = null;
            }

            _rectTransform.position = inputPosition;
        }

        private void OnClickFinished(Vector2 inputPosition)
        {
            if (_isDragged == false)
                return;

            _isDragged = false;

            foreach (RectTransform rect in _cellsTransform)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, new Vector2(inputPosition.x, inputPosition.y)))
                {
                    _cell = rect.gameObject.GetComponent<Cell>();
                    _cell.SetCommand(_command, this);

                    transform.position = rect.position;
                    return;
                }
            }

            DestroyUI();
        }

        private void DestroyUI()
        {
            transform
                .DOScale(0, _destroyDuration)
                .OnComplete(() => Destroy(gameObject));

            enabled = false;
        }

        public class Factory : PlaceholderFactory<UIElement, Transform, UIElement>
        {
        }
    }
}