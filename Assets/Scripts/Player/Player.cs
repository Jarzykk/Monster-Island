using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private MinionsFollowPosition _minionsFollowPosition;
    [SerializeField] private Transform _takeCoinPosition;
    [SerializeField] private Wallet _wallet;

    public MinionsFollowPosition MinionsFollowPosition => _minionsFollowPosition;
    public int CoinsAmount => _wallet.CoinsAmount;
    public Transform TakeCoinPosition => _takeCoinPosition;

    public event UnityAction TookCoin;

    public void TakeCoin()
    {
        _wallet.TakeCoin();
        TookCoin?.Invoke();
    }
}
