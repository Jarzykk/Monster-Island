using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTaker : MonoBehaviour
{
    [SerializeField] private PlatformUnlocker _platformUnlocker;
    [SerializeField] private CoinReciever _coinReciever;
    [SerializeField] private float _delayBetweenTakeCoin;
    [SerializeField] private Transform _coinLaunchPosition;

    private bool _takeCoinAllowed;
    private float _timeCount;
    private int _coinsTaken;

    private void Start()
    {
        _takeCoinAllowed = true;
        _coinsTaken = 0;
    }

    private void OnTriggerStay(Collider other)
    {        
        if(other.TryGetComponent<Wallet>(out Wallet wallet))
        {
            if (_takeCoinAllowed == true && _coinsTaken < _platformUnlocker.CoinPriceToUnlock)
            {
                bool coinTaken = wallet.TryPayCoin(_coinLaunchPosition.position, _coinReciever.CoinRecievePosition.transform.position);
                if(coinTaken == true)
                {
                    _coinsTaken++;
                    _takeCoinAllowed = false;
                }
            }
        }
    }

    private void Update()
    {
        _timeCount += Time.deltaTime;

        if (_timeCount >= _delayBetweenTakeCoin)
        {            
            _takeCoinAllowed = true;
            _timeCount = 0;
        }        
    }
}
