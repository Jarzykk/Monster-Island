using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUnlocker : MonoBehaviour
{
    [SerializeField] private int _coinPriceToUnlock;
    [SerializeField] private List<Platform> _platformsToUnlock = new List<Platform>();
    [SerializeField] private CoinTaker _coinTaker;
    [SerializeField] private CoinReciever _coinReciever;
    [SerializeField] private EnemySpawner _enemySpawner;

    private Enemy _enemyActivator;
    private int _coinsToUnlockLeft;

    public int CoinPriceToUnlock => _coinPriceToUnlock;
    public int CoinsToUnlockLeft => _coinsToUnlockLeft;

    private void Start()
    {
        _coinTaker.gameObject.SetActive(false);
        _coinReciever.gameObject.SetActive(false);

        foreach (var platform in _platformsToUnlock)
        {
            platform.gameObject.SetActive(false);
        }

        _coinsToUnlockLeft = _coinPriceToUnlock;
    }

    private void OnEnable()
    {
        _enemySpawner.EnemyHasBeenSpawned += OnEnemySpawned;
        _coinReciever.CoinRecieved += OnCoinRecieved;
    }

    private void OnDisable()
    {
        _enemySpawner.EnemyHasBeenSpawned -= OnEnemySpawned;
        _coinReciever.CoinRecieved -= OnCoinRecieved;
    }

    private void OnEnemyDying()
    {
        _enemyActivator.Died -= OnEnemyDying;

        _coinTaker.gameObject.SetActive(true);
        _coinReciever.gameObject.SetActive(true);
    }

    private void OnCoinRecieved()
    {
        _coinsToUnlockLeft--;

        if(_coinsToUnlockLeft <= 0)
        {
            foreach (var platform in _platformsToUnlock)
            {
                platform.gameObject.SetActive(true);
            }

            Destroy(gameObject);
        }
    }

    private void OnEnemySpawned(Enemy enemy)
    {
        _enemyActivator = enemy;
        _enemyActivator.Died += OnEnemyDying;
    }
}
