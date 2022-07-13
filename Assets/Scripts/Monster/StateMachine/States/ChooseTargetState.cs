using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChooseTargetState : State
{
    [SerializeField] private MonsterTargetSystem _targetSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<Monster>(out Monster target) && _targetSystem.Target == null)
        {
            _targetSystem.TrySetTarget(target);
        }
    }
}
