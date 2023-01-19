using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDyingState : State
{
    [SerializeField] CoinSpawner _coinSpawner;
    [SerializeField] private Vector3 _targetMinScaleBeforeDie;
    [SerializeField] private float _minimazingDuration;

    private Vector3 _startScale;

    private void OnEnable()
    {
        _coinSpawner.AllCoinsSpawned += OnAllCoinsSpawned;
        _startScale = transform.localScale;
    }

    private void OnDisable()
    {
        _coinSpawner.AllCoinsSpawned -= OnAllCoinsSpawned;
    }

    private void OnAllCoinsSpawned()
    {
        StartCoroutine(MinimazeScaleBeforeDestraction());
    }

    private IEnumerator MinimazeScaleBeforeDestraction()
    {
        float runningTime = 0;

        while(runningTime < _minimazingDuration)
        {
            transform.localScale = Vector3.Lerp(_startScale, _targetMinScaleBeforeDie, runningTime / _minimazingDuration);
            runningTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        Destroy(gameObject);        
    }
}
