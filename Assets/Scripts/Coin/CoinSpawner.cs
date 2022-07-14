using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _delayBetweenCoinsCreation;
    [SerializeField] private Transform[] _targetPositions;

    private int _amountToSpawn => _targetPositions.Length;

    public event UnityAction AllCoinsSpawned;

    private void OnEnable()
    {
        _enemy.Died += OnEnemyDeath;
    }

    private void OnDisable()
    {
        _enemy.Died -= OnEnemyDeath;
    }

    private void OnEnemyDeath()
    {
        gameObject.transform.parent = null;
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _amountToSpawn; i++)
        {
            yield return new WaitForSeconds(_delayBetweenCoinsCreation);
            Coin coin = Instantiate(_coinTemplate, transform.position, Quaternion.identity);
            coin.LaunchProjectileFlightAfterCreation(_targetPositions[i].position);
        }

        AllCoinsSpawned?.Invoke();
        Destroy(gameObject);
    }
}
