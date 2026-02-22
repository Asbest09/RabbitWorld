using Assets.Scripts.BasicLogic.Service.Data;
using Assets.Scripts.BasicLogic.View;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private StopButton _stopButton;
    [SerializeField] private UiElementsParent _uiElementsParent;
    [SerializeField] private CellParent _cellParent;
    [SerializeField] private WorldGenerator _worldGenerator;

    private StaticDataService _staticDataService;
    private PlayerModel _playerModel;
    private float _cellSize;
    private Vector2Int _startPoint;
    private DiContainer _container;

    [Inject]
    private void Constructor(StaticDataService staticDataService, PlayerModel playerModel, UIFactory factory, UIElement.Factory uIFactory, List<Cell> cells, IInputService inputService, DiContainer container, Engine engine, Dictionary<string, Command> commandTypes)
    {
        _playerModel = playerModel;
        _staticDataService = staticDataService;
        _container = container;

        _uiElementsParent.Init(factory, uIFactory, staticDataService, inputService, commandTypes);
        _cellParent.Init(staticDataService, container, engine);
        _worldGenerator.Init(staticDataService);
    }

    private void Awake()
    {
        DOTween.Init(true, false);

        SpawnPlayer();

        _stopButton.Init(_playerModel);
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

        PlayerMovement player = Instantiate(_playerPrefab, startPosition, initialPoint.rotation).GetComponent<PlayerMovement>();
        player.Init(_staticDataService, _playerModel);
    }
}