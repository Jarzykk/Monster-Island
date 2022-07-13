using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsDisabler : MonoBehaviour
{
    [SerializeField] private StateMachine _stateMachine;
    [SerializeField] private MinionTargetSystem _targetSystem;
    [SerializeField] private Animator _animator;
    [SerializeField] private MonsterAnimationController _animationController;

    public void DisableComponentsforUi()
    {
        _stateMachine.enabled = false;
        _targetSystem.enabled = false;
    }

    public void DisableAnimations()
    {
        _animationController.enabled = false;
        _animator.enabled = false;
    }
}
