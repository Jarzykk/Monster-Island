using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyToSpawn;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _delayBeforeSpawn;

    private Enemy _enemySpawned;

    public event UnityAction<Enemy> EnemyHasBeenSpawned;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(_delayBeforeSpawn);

        _enemySpawned = Instantiate(_enemyToSpawn, _spawnPosition.position, Quaternion.identity);
        EnemyHasBeenSpawned?.Invoke(_enemySpawned);
    }
}
