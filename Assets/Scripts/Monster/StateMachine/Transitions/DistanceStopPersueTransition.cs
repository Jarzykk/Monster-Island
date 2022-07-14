using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Monster))]
public class DistanceStopPersueTransition : Transition
{
    [SerializeField] private float _distanceToTransit;
    private Monster _monster;

    private void Start()
    {
        _monster = GetComponent<Monster>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _monster.CurrentTarget.transform.position) < _distanceToTransit)
            NeedTransit = true;
    }
}
