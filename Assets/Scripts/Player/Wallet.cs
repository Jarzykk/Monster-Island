using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    [SerializeField] private Coin _coinTemplate;
    [SerializeField] private float _delayBetweenDropCoins;

    private int _coinsAmount;

    public int CoinsAmount => _coinsAmount;

    public event UnityAction<int> CoinsAmountChanged;
    public event UnityAction Payed;

    public void TakeCoin()
    {
        _coinsAmount++;
        CoinsAmountChanged?.Invoke(_coinsAmount);
    }

    public bool TryPayCoin(Vector3 CoinLaunchPosition, Vector3 positionForCoinsToFall)
    {
        if (_coinsAmount > 0)
        {
            _coinsAmount--;
            CoinsAmountChanged?.Invoke(_coinsAmount);
            Payed?.Invoke();
            Coin coin = Instantiate(_coinTemplate, CoinLaunchPosition, Quaternion.identity);
            coin.LaunchProjectileFlightAfterCreation(positionForCoinsToFall);
            return true;
        }
        else
        {
            return false;
        }
    }
}
