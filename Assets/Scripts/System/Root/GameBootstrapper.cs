using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.View;
using DG.Tweening;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private StopButton _stopButton;
    [SerializeField] private UiElementsParent _uiElementsParent;
    [SerializeField] private CellParent _cellParent;
    [SerializeField] private WorldGenerator _worldGenerator;
    [SerializeField] private VictoryParent _victoryParent;
    [SerializeField] private NextLevelButton _nextLevelButton;

    private StaticDataService _staticDataService;
    private PlayerModel _playerModel;
    private float _cellSize;
    private Vector2Int _startPoint;
    private DiContainer _container;
    private PlayerMovement _playerMovement;

    [Inject]
    private void Constructor(StaticDataService staticDataService, PlayerModel playerModel, UIFactory factory, UIElement.Factory uIFactory, List<Cell> cells, IInputService inputService, DiContainer container, Engine engine, LevelLoader levelLoader)
    {
        _playerModel = playerModel ?? throw new ArgumentNullException(nameof(playerModel));
        _staticDataService = staticDataService ?? throw new ArgumentNullException(nameof(staticDataService));
        _container = container ?? throw new ArgumentNullException(nameof(container));

        _uiElementsParent.Init(factory, uIFactory, staticDataService, inputService);
        _cellParent.Init(staticDataService, container, engine);
        _worldGenerator.Init(staticDataService);
        _nextLevelButton.Init(levelLoader);
    }

    private void OnDisable()
    {
        _playerMovement.CompleteLevel -= _victoryParent.Complete;
        _stopButton.Close -= _victoryParent.Close;
    }

    private void Awake()
    {
        SpawnPlayer();

        _stopButton.Init(_playerModel);
        _stopButton.Close += _victoryParent.Close;
    }

    private void Start()
    {
        _uiElementsParent.GetCells(_container.Resolve<List<Cell>>());
    }

    private void SpawnPlayer()
    {
        Transform initialPoint = GameObject.FindWithTag("PlayerInitialPoint").transform;
        _cellSize = _staticDataService.GetPanelSize();
        _startPoint = _staticDataService.GetStartPoint();

        Vector3 startPosition = initialPoint.position + new Vector3(_startPoint.x * _cellSize, 0, _startPoint.y * _cellSize);

        _playerMovement = Instantiate(_playerPrefab, startPosition, initialPoint.rotation).GetComponent<PlayerMovement>();
        _playerMovement.Init(_staticDataService, _playerModel);
        _playerMovement.CompleteLevel += _victoryParent.Complete;
    }
}