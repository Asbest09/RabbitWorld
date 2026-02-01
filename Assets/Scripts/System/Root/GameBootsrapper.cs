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

        PlayerMovement player = Instantiate(_playerPrefab, initialPoint).GetComponent<PlayerMovement>();
        player.Init(_staticDataService, _playerModel);
    }
}