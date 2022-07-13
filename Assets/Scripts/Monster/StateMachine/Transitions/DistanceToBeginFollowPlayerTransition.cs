using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Minion))]
public class DistanceToBeginFollowPlayerTransition : Transition
{
    [SerializeField] private float _distanceToTransit;
    private Minion _minion;

    private void Start()
    {
        _minion = GetComponent<Minion>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _minion.Player.transform.position) > _distanceToTransit)
            NeedTransit = true;
    }
}
