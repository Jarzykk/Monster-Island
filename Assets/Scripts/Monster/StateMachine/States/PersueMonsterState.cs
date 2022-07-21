using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class PersueMonsterState : State
{
    [SerializeField] private float _speed;
    private Vector3 _currentTargetPosition;
    private Monster _monster;

    private void OnEnable()
    {
        _monster = GetComponent<Monster>();
        _monster.LauchStartedMovementEvent();
    }

    private void OnDisable()
    {
        _monster.LaunchStopedMovementEvent();
    }

    private void FixedUpdate()
    {
        if(_monster.CurrentTarget != null)
        {
            _currentTargetPosition = _monster.CurrentTarget.transform.position;
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTargetPosition, _speed * Time.deltaTime);
    }

    private void Rotate()
    {
        Vector3 targetMoveDirection = (_currentTargetPosition - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(targetMoveDirection);
    }
}
