using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackState), typeof(Monster))]
public class MonsterAnimationHandler : MonoBehaviour
{
    [SerializeField] private MonsterAnimations _animations;

    private AttackState _attackState;
    private Monster _monster;

    private void Awake()
    {
        _attackState = GetComponent<AttackState>();
        _monster = GetComponent<Monster>();
    }

    private void OnEnable()
    {
        _monster.StartedMovement += OnStartedToMove;
        _monster.StopedMovement += OnStopedMovement;
        _attackState.Attacked += OnAttack;
        _monster.Died += OnDeath;
    }

    private void OnDisable()
    {
        _monster.StartedMovement -= OnStartedToMove;
        _monster.StopedMovement -= OnStopedMovement;
        _attackState.Attacked -= OnAttack;
        _monster.Died -= OnDeath;
    }

    private void OnStartedToMove()
    {
        _animations.ActivateMovingAnimation();
    }

    private void OnStopedMovement()
    {
        _animations.DeactivateMovingAnimation();
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
