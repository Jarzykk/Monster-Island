using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private Vector3 _cameraOffset;

    private void Start()
    {
        _cameraOffset = transform.position - _playerController.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = _playerController.transform.position + _cameraOffset;
    }
}
