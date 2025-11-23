using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIElement : MonoBehaviour, IDisposable
    {
        [Inject] private List<Cell> _cells;
        [Inject] private IInputService _inputService;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Command _command;

        private bool _isDragged;
        private RectTransform[] _cellsTransform;
        private float _destroyDuration = 1f;

        private void Start()
        {
            _inputService.ClickStarted += OnClicked;
            _inputService.ClickFinished += OnClickFinished;
            _inputService.Dragged += OnDragged;

            _cellsTransform = new RectTransform[_cells.Count];

            for (int i = 0; i < _cells.Count; i++)
                _cellsTransform[i] = _cells[i].gameObject.GetComponent<RectTransform>();
        }

        public void Dispose()
        {
            _inputService.ClickStarted -= OnClicked;
            _inputService.ClickFinished -= OnClickFinished;
            _inputService.Dragged -= OnDragged;
        }

        private void OnClicked(Vector2 inputPosition)
        {
            _isDragged = RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, new Vector2(inputPosition.x, inputPosition.y));

            if (_isDragged)
            {
                CreateCommand();
            }
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

            foreach (RectTransform rect in _cellsTransform)
            {
                if (RectTransformUtility.RectangleContainsScreenPoint(rect, new Vector2(inputPosition.x, inputPosition.y)))
                {
                    rect.gameObject.GetComponent<Cell>().SetCommand(_command);

                    transform.position = rect.position;
                    return;
                }
            }

            DestroyUI();
        }

        private void DestroyUI()
        {
            transform.DOScale(0, _destroyDuration);
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(_destroyDuration);
            Destroy(gameObject);
        }

        private void CreateCommand()
        {
            new UIFactory(gameObject.name, transform);
        }

        public class Factory : PlaceholderFactory<UIElement, Transform, UIElement>
        {
        }
    }
}