using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController), typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private PlayerController _playerController;
    private Animator _animator;

    private const string _startedMovementTriggerName = "StartedMovement";
    private const string _stoppedMovementTriggerName = "StopedMovement";

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerController.Moved += OnPlayerMoved;
        _playerController.StopedMovement += OnPlayerStopped;
    }

    private void OnDisable()
    {
        _playerController.Moved -= OnPlayerMoved;
        _playerController.StopedMovement -= OnPlayerStopped;
    }

    private void OnPlayerMoved()
    {
        _animator.SetTrigger(_startedMovementTriggerName);
    }

    private void OnPlayerStopped()
    {
        _animator.SetTrigger(_stoppedMovementTriggerName);
    }
}
