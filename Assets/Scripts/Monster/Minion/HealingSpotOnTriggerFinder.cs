using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class HealingSpotOnTriggerFinder : MonoBehaviour
{
    private bool _isOnHealingSpot = false;

    public event UnityAction EnteredHealingSpot;
    public event UnityAction LeftHealingSpot;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<HealingSpot>())
        {
            if(_isOnHealingSpot == false)
            {
                _isOnHealingSpot = true;
                EnteredHealingSpot?.Invoke();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<HealingSpot>())
        {
            if (_isOnHealingSpot == true)
            {
                _isOnHealingSpot = false;
                LeftHealingSpot?.Invoke();
            }
        }
    }
}
