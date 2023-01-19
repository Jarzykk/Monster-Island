using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingTransition : Transition
{
    private Monster _monster;

    private void OnEnable()
    {
        _monster = GetComponent<Monster>();
        _monster.Died += OnDeath;
    }

    private void OnDisable()
    {
        _monster.Died -= OnDeath;
    }

    private void OnDeath()
    {
        NeedTransit = true;
    }
}
