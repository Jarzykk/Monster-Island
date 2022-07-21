using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MonsterAnimations : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private const string _attackTriggetName = "Attacked";
    private const string _roarTriggetName = "Roar";
    private const string _dieTriggetName = "Died";
    private const string _movingBoolName = "IsMoving";

    public void TriggerAttackAnimation()
    {
        _animator.SetTrigger(_attackTriggetName);
    }

    public void TriggerRoarAnimation()
    {
        _animator.SetTrigger(_roarTriggetName);
    }

    public void TriggerDieAnimation()
    {
        _animator.SetTrigger(_dieTriggetName);
    }

    public void ActivateMovingAnimation()
    {
        _animator.SetBool(_movingBoolName, true);
    }

    public void DeactivateMovingAnimation()
    {
        _animator.SetBool(_movingBoolName, false);
    }

    public void Roar()
    {
        _animator.SetTrigger(_roarTriggetName);
    }
}
