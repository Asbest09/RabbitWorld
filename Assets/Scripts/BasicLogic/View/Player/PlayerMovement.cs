using Assets.Scripts.BasicLogic.Service.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3 _target;
    private StaticDataService _staticDataService;
    private float _panelSize;

    private void Start()
    {
        _target = transform.position;
        _panelSize = _staticDataService.GetPanelSize();
    }

    public void Init(StaticDataService staticDataService, PlayerModel playerModel)
    {
        _staticDataService = staticDataService;
        playerModel.MoveAction += Move;
    }

    private void Move(Queue<Vector2Int> steps)
    {
        StartCoroutine(MoveSteps(steps));
    }

    private IEnumerator MoveSteps(Queue<Vector2Int> steps)
    {
        while (steps.Count > 0)
        {
            Vector2Int step = steps.Dequeue();
            _target = new Vector3(step.x * _panelSize, 0, step.y * _panelSize);

            transform.Translate(_target);
            
            yield return new WaitForSeconds(_panelSize / _speed);
        }
    }
}
