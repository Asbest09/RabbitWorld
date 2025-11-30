using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.BasicLogic.View
{
    public class UIElement : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Command _command;

        private List<Cell> _cells;
        private IInputService _inputService;

        private bool _isDragged;
        private RectTransform[] _cellsTransform;
        private float _destroyDuration = 1f;
        private Factory _factory;

        [Inject]
        private void Construct(UIElement.Factory factory, List<Cell> cells, IInputService inputService)//factory - излишняя ответственность
        {
            _factory = factory;
            _cells = cells;
            _inputService = inputService;
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

        private void OnDestroy()
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
            transform
                .DOScale(0, _destroyDuration)
                .OnComplete(()=> Destroy(gameObject));
        }

        private void CreateCommand()//
        {
            Debug.Log("<color=red> " + _factory != null);
            new UIFactory(gameObject.name, transform, _factory);
        }

        public class Factory : PlaceholderFactory<UIElement, Transform, UIElement>
        {
        }
    }
}