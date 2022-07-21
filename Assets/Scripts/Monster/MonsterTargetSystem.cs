using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class MonsterTargetSystem : MonoBehaviour
{
    private Monster _target;

    public Monster Target => _target;

    public event UnityAction TargetWasSet;
    public event UnityAction TargetDied;

    public virtual void TrySetTarget(Monster target)
    {
        if(target.CurrentHealth > 0)
        {
            _target = target;
            _target.Died += OnTargetDeath;
            TargetWasSet?.Invoke();
        }        
    }

    private void OnTargetDeath()
    {
        _target = null;
        TargetDied?.Invoke();
    }
}
