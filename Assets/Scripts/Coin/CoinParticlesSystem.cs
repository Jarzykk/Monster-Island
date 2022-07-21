using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Coin))]
public class CoinParticlesSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bangParticle;

    private Coin _coin;

    private void OnEnable()
    {
        _coin = GetComponent<Coin>();
        _coin.Landed += PlayBangParticle;
    }

    private void OnDisable()
    {
        _coin.Landed -= PlayBangParticle;
    }

    private void PlayBangParticle()
    {
        _bangParticle.Play();
    }
}
