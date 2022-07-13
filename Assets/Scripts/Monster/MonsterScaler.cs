using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScaler : MonoBehaviour
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private Vector3 _targetScale;
    [SerializeField] private float _duration;

    private float _durationRunningTime = 0;

    private void OnEnable()
    {
        transform.localScale = _startScale;
    }

    private void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(_startScale, _targetScale, _durationRunningTime / _duration);
        _durationRunningTime += Time.deltaTime;

        if (transform.localScale == _targetScale)
            this.enabled = false;
    }
}
