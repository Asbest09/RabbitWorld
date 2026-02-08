using Assets.Scripts.BasicLogic.Service.Data;
using DG.Tweening;
using UnityEngine;
using Zenject;

public class GameBootsrapper : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private StopButton _stopButton;

    private StaticDataService _staticDataService;
    private PlayerModel _playerModel;
    private float _cellSize;
    private Vector2Int _startPoint;

    private void Awake()
    {
        DOTween.Init(true, false);

        SpawnPlayer();

        _stopButton.Init(_playerModel);
    }

    [Inject] private void Constructor(StaticDataService staticDataService, PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _staticDataService = staticDataService;
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