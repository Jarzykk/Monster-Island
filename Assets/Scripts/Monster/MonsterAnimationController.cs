using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackState), typeof(Monster))]
public class MonsterAnimationController : MonoBehaviour
{
    [SerializeField] private MonsterAnimations _animations;
    private AttackState _attackState;
    private Monster _monster;

    private Vector3 _lastMonsterPosition;
    private bool _wasMoving;

    private void Awake()
    {
        _attackState = GetComponent<AttackState>();
        _monster = GetComponent<Monster>();
        _lastMonsterPosition = transform.position;
        _wasMoving = false;
    }

    private void OnEnable()
    {
        _attackState.Attacked += OnAttack;
        _monster.Died += OnDeath;
    }

    private void OnDisable()
    {
        _attackState.Attacked -= OnAttack;
        _monster.Died -= OnDeath;
    }

    private void FixedUpdate()
    {
        if (_lastMonsterPosition != transform.position && _wasMoving == false)
        {
            _animations.ActivateMovingAnimation();
            _wasMoving = true;
        }
        else if(_lastMonsterPosition == transform.position && _wasMoving == true)
        {
            _animations.DeactivateMovingAnimation();
            _wasMoving = false;
        }

        _lastMonsterPosition = transform.position;
    }

    private void OnAttack()
    {
        _animations.TriggerAttackAnimation();
    }

    private void Roar()
    {
        _animations.TriggerRoarAnimation();
    }

    private void OnDeath()
    {
        _animations.TriggerDieAnimation();
    }
}
