using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem _glowingTrailEffect;

    private Player _player;

    private void OnEnable()
    {
        _player = GetComponent<Player>();
        _player.TookCoin += PlayGlowingTrailEffect;
    }

    private void OnDisable()
    {
        _player.TookCoin -= PlayGlowingTrailEffect;
    }

    private void PlayGlowingTrailEffect()
    {
        _glowingTrailEffect.Stop();
        _glowingTrailEffect.Play();
    }
}
