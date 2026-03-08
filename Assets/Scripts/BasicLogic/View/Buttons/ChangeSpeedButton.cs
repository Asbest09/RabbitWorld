using Assets.Scripts.BasicLogic.View.Player;
using UnityEngine;

public class ChangeSpeedButton : MonoBehaviour
{
    [SerializeField] float _maxSpeedFactor;
    [SerializeField] float _minSpeedFactor;
    [SerializeField] float _speedFactor;

    private PlayerMovement _playerMovement;
    private float _currentFactor = 1f;

    public void Init(PlayerMovement playerMovement)
    {
        _playerMovement = playerMovement;
    }

    public void BoostSpeed()
    {
        float tempFactor = _currentFactor;
        if (_currentFactor * _speedFactor >= _maxSpeedFactor)
            tempFactor = _maxSpeedFactor;
        else
            tempFactor *= _speedFactor;

        if (_playerMovement.SetSpeedFactor(tempFactor))
            _currentFactor = tempFactor;
    }

    public void SlowSpeed()
    {
        float tempFactor = _currentFactor;
        if (_currentFactor / _speedFactor <= _minSpeedFactor)
            tempFactor = _minSpeedFactor;
        else
            tempFactor /= _speedFactor;

        if(_playerMovement.SetSpeedFactor(tempFactor))
            _currentFactor = tempFactor;
    }
}
