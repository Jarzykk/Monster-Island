using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttackState))]
public class MonsterEffectController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectAfterCreation;
    [SerializeField] private ParticleSystem _hitEffect;
    [SerializeField] private bool _playCreationEffect;

    private AttackState _attackState;

    private void Awake()
    {
        _attackState = GetComponent<AttackState>();
    }

    private void OnEnable()
    {
        if(_playCreationEffect)
            _effectAfterCreation.Play();

        _attackState.Attacked += OnHit;
    }

    private void OnDisable()
    {
        _attackState.Attacked -= OnHit;
    }

    private void OnHit()
    {
        _hitEffect.Play();
    }
}
