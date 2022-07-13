using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Minion))]
public class FollowPlayerState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private float _accesibleXAxisErrorToTargetPosition;
    private Vector3 _targetPosition;
    private Vector3 _targetPositionWithError;
    private Minion _minion;

    private float _xAxisError;

    private void Start()
    {
        _xAxisError = Random.Range(- _accesibleXAxisErrorToTargetPosition, _accesibleXAxisErrorToTargetPosition);
        _minion = GetComponent<Minion>();
    }

    private void FixedUpdate()
    {
        _targetPosition = _minion.Player.MinionsFollowPosition.transform.position;
        _targetPositionWithError = new Vector3(_targetPosition.x + _xAxisError, _targetPosition.y, _targetPosition.z);
        Move(_targetPositionWithError);
        Rotate(_targetPositionWithError);
    }

    private void Move(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    private void Rotate(Vector3 targetPosition)
    {
        Vector3 targetMoveDirection = (targetPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(targetMoveDirection);
    }
}
