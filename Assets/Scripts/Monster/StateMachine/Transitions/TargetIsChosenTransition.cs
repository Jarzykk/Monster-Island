using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class TargetIsChosenTransition : Transition
{
    private Monster _monster;

    private void OnEnable()
    {
        _monster = GetComponent<Monster>();        
    }

    private void Update()
    {
        if (_monster.CurrentTarget != null)
            NeedTransit = true;
    }
}
