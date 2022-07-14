using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Coin : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private float _coinFlightSpeed;
    [SerializeField] private MagnetizeToPlayer _magnet;

    private bool _coinLanded = false;

    public event UnityAction Landed;
    public event UnityAction WasTaken;

    private void OnEnable()
    {
        _magnet.CollidedWithPlayer += OnCollisionWithPlayer;
        _magnet.enabled = false;
    }

    private void OnDisable()
    {
        _magnet.CollidedWithPlayer -= OnCollisionWithPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_coinLanded == true && other.TryGetComponent<Player>(out Player player))
        {
            OnPlayerEnteredTrigger(player);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>())
        {
            OnCollisionWithGround();
        }
    }

    public void LaunchProjectileFlightAfterCreation(Vector3 target)
    {
        _rigidBody.velocity = CalculateProjectileVelocity(target, transform.position, _coinFlightSpeed);
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }

    private void OnPlayerEnteredTrigger(Player player)
    {
        _magnet.enabled = true;
        _magnet.StartFlight(player, _rigidBody);
    }

    private void OnCollisionWithPlayer(Player player)
    {
        player.TakeCoin();
        WasTaken?.Invoke();
        Destroy(gameObject);
    }

    private void OnCollisionWithGround()
    {
        _coinLanded = true;
        _rigidBody.isKinematic = true;
        _rigidBody.useGravity = false;
        Landed?.Invoke();
    }

    private Vector3 CalculateProjectileVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        Vector3 distanceByAxisXZ = distance;
        distanceByAxisXZ.Normalize();
        distanceByAxisXZ.y = 0;

        float distansYAxis = distance.y;
        float distanceXZAxis = distance.magnitude;

        float velocityXZ = distanceXZAxis / time;

        float velocityY = distansYAxis / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceByAxisXZ * velocityXZ;
        result.y = velocityY;

        return result;
    }
}
