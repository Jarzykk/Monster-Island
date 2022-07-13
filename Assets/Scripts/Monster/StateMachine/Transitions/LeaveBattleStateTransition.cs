using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Monster))]
public class LeaveBattleStateTransition : Transition
{
    private Monster _monster;
    private Monster _target;

    public event UnityAction LeftBattleState;

    private void OnEnable()
    {
        NeedTransit = false;
        _monster = GetComponent<Monster>();
        _target = _monster.CurrentTarget;
        _target.Died += OnEnemyDeath;
    }

    private void OnDisable()
    {
        _target.Died -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        LeftBattleState?.Invoke();
        NeedTransit = true;
    }
}
