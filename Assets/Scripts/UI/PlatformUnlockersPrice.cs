using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformUnlockersPrice : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private PlatformUnlocker _platformUnlocker;
    [SerializeField] private CoinReciever _coinReciever;

    private void OnEnable()
    {
        _price.text = _platformUnlocker.CoinsToUnlockLeft.ToString();
        _coinReciever.CoinRecieved += OnCoinRecieved;
    }

    private void OnDisable()
    {
        _coinReciever.CoinRecieved -= OnCoinRecieved;
    }

    private void OnCoinRecieved()
    {
        _price.text = _platformUnlocker.CoinsToUnlockLeft.ToString();
    }
}
