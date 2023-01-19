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

    private void OnDisable()
    {
        _target.Died -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        LeftBattleState?.Invoke();
        NeedTransit = true;
    }

    protected override void Enabled()
    {
        base.Enabled();
        _monster = GetComponent<Monster>();
        _target = _monster.CurrentTarget;
        _target.Died += OnEnemyDeath;
    }
}
