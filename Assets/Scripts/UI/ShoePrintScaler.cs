using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePrintScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _shoeSprite;
    [SerializeField] private Vector3 _targetMaxScale;
    [SerializeField] private Vector3 _targetMinScale;
    [SerializeField] private float _duration;

    private float _durationRunningTime;
    private bool _scaleIncreasing = true;

    private void FixedUpdate()
    {
        if(_shoeSprite.transform.localScale == _targetMaxScale && _scaleIncreasing == true)
        {
            OnTargetScaleReached();
        }
        else if(_shoeSprite.transform.localScale == _targetMinScale && _scaleIncreasing == false)
        {
            OnTargetScaleReached();
        }

        if(_scaleIncreasing)
        {
            _shoeSprite.transform.localScale = Vector3.Lerp(_targetMinScale, _targetMaxScale, _durationRunningTime / _duration);            
        }
        else
        {
            _shoeSprite.transform.localScale = Vector3.Lerp(_targetMaxScale, _targetMinScale, _durationRunningTime / _duration);
        }

        _durationRunningTime += Time.deltaTime;
    }

    private void OnTargetScaleReached()
    {
        _scaleIncreasing = !_scaleIncreasing;
        _durationRunningTime = 0;
    }
}
