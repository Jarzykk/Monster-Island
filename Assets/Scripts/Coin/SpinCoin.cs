using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Coin))]
public class SpinCoin : MonoBehaviour
{
    [SerializeField] private float _rotateSpeedByYAngle;

    private Coin _coin;

    private void Start()
    {
        _coin = GetComponent<Coin>();
    }

    private void FixedUpdate()
    {
        _coin.transform.Rotate(0, _rotateSpeedByYAngle, 0, Space.World);
    }
}
