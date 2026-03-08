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
        if(_currentFactor == _maxSpeedFactor)
            return;
        else if(_currentFactor * _speedFactor > _maxSpeedFactor)
            _currentFactor = _maxSpeedFactor;
        else
            _currentFactor *= _speedFactor;

        _playerMovement.SetSpeedFactor(_currentFactor);
    }

    public void SlowSpeed()
    {
        if (_currentFactor == _minSpeedFactor)
            return;
        else if (_currentFactor / _speedFactor < _minSpeedFactor)
            _currentFactor = _minSpeedFactor;
        else
            _currentFactor /= _speedFactor;

        Debug.Log("slow");

        _playerMovement.SetSpeedFactor(1 / _currentFactor); // неправильно работает
    }
}
