using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _moveSpeed;
    private bool _isMoving => _fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0;
    private bool _wasMoving = false;

    public event UnityAction Moved;
    public event UnityAction StopedMovement;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_fixedJoystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _fixedJoystick.Vertical * _moveSpeed);

        if (_isMoving)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z));

            if(_wasMoving == false)
            {
                _wasMoving = true;
                Moved?.Invoke();
            }
        }
        else if(_isMoving == false && _wasMoving == true)
        {
            StopedMovement?.Invoke();
            _wasMoving = false;
        }
    }
}
