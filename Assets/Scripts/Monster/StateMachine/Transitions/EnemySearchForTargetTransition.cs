using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider), typeof(EnemyTargetSystem))]
public class EnemySearchForTargetTransition : Transition
{
    private BoxCollider _collider;
    private EnemyTargetSystem _targetSystem;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _targetSystem = GetComponent<EnemyTargetSystem>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Minion>(out Minion minion))
            if (minion.CurrentHealth > 0 && _targetSystem.Target == null)
                NeedTransit = true;
    }
}
