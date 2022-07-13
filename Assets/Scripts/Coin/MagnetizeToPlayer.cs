using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagnetizeToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player _player;
    private Rigidbody _rigidBody;
    private bool _canFly = false;

    public event UnityAction<Player> CollidedWithPlayer;

    private void Update()
    {
        if(_canFly)
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.TakeCoinPosition.position, _speed * Time.deltaTime);
        }
    }

    public void StartFlight(Player player, Rigidbody rigidBody)
    {
        _rigidBody = rigidBody;
        _player = player;
        _canFly = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            OnCollisionWithPlayer(player);
        }
    }

    private void OnCollisionWithPlayer(Player player)
    {
        CollidedWithPlayer?.Invoke(player);
        _canFly = false;
        this.enabled = false;
    }
}
