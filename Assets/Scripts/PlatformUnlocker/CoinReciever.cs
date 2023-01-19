using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinReciever : MonoBehaviour
{
    [SerializeField] private Transform _coinRecievePosition;

    private int _coinsRecieved = 0;

    public Transform CoinRecievePosition => _coinRecievePosition;
    public int CoinsRecieved => _coinsRecieved;

    public event UnityAction CoinRecieved;

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent<Coin>(out Coin coin))
        {
            coin.DestroyCoin();
            _coinsRecieved++;
            CoinRecieved?.Invoke();
        }
    }
}
