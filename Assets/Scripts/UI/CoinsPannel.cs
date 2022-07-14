using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsPannel : MonoBehaviour
{
    [SerializeField] private Wallet _playersWallet;
    [SerializeField] private TMP_Text _coinsCountText;

    private const int _startCoinsAmount = 0;

    private void Start()
    {
        _coinsCountText.text = _startCoinsAmount.ToString();
    }

    private void OnEnable()
    {
        _playersWallet.CoinsAmountChanged += OnCoinsAmountChange;
    }

    private void OnDisable()
    {
        _playersWallet.CoinsAmountChanged -= OnCoinsAmountChange;
    }

    private void OnCoinsAmountChange(int coinsAmount)
    {
        _coinsCountText.text = coinsAmount.ToString();
    }
}
