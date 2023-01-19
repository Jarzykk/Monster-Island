using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoePrintScaler : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _shoeSprite;
    [SerializeField] private Vector3 _targetMaxScale;
    [SerializeField] private Vector3 _targetMinScale;
    [SerializeField] private float _duration;

    private void OnEnable()
    {
        _shoeSprite.transform.localScale = _targetMinScale;
        StartCoroutine(ScaleLoop());
    }

    private IEnumerator ScaleLoop()
    {
        while (true)
        {
            yield return ScaleTo(_targetMaxScale);
            yield return ScaleTo(_targetMinScale);
        }
    }

    private IEnumerator ScaleTo(Vector3 scale)
    {
        float durationRunningTime = 0;

        while (_shoeSprite.transform.localScale != scale)
        {
            _shoeSprite.transform.localScale = Vector3.Lerp(_shoeSprite.transform.localScale, scale, durationRunningTime / _duration);
            durationRunningTime += Time.deltaTime;
            yield return null;
        }
    }
}
