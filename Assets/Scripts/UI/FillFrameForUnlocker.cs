using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFrameForUnlocker : MonoBehaviour
{
    [SerializeField] private Image _imageToFill;
    [SerializeField] private PlatformUnlocker _unlocker;
    [SerializeField] private CoinReciever _reciever;

    private void OnEnable()
    {
        ChangeFillAmount();
        _reciever.CoinRecieved += ChangeFillAmount;
    }

    private void OnDisable()
    {
        _reciever.CoinRecieved -= ChangeFillAmount;
    }

    private void ChangeFillAmount()
    {
        _imageToFill.fillAmount = (float)_reciever.CoinsRecieved / _unlocker.CoinPriceToUnlock;
    }
}
