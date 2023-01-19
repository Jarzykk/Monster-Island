using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MagnetizeToPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void StartFlight(Transform targetTransform, Rigidbody rigidBody)
    {
        StartCoroutine(FlyToTarget(targetTransform));
    }

    private IEnumerator FlyToTarget(Transform targetPosition)
    {
        while(transform.position != targetPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
