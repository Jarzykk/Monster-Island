using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUIForCamera : MonoBehaviour
{
    private MainCamera _mainCamera;

    private void Awake()
    {
        _mainCamera = FindObjectOfType<MainCamera>();
    }

    private void FixedUpdate()
    {
        transform.rotation = _mainCamera.transform.rotation;
    }
}
