using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingSpot : MonoBehaviour
{
    [SerializeField] private float _healingRate;
    [SerializeField] private int _amountToHeal;

    private float _timeCount;
    private List<Health> _healthToHeal = new List<Health>();

    private void Start()
    {
        if (_amountToHeal <= 0)
            throw new System.Exception("Wrong argument");

        _timeCount = _healingRate;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Minion>(out Minion minion))
        {
            if (minion.TryGetComponent<Health>(out Health health))
            {
                TryAddHealthToList(health);
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Minion>(out Minion minion))
        {
            if (minion.TryGetComponent<Health>(out Health health))
            {
                _healthToHeal.Remove(health);
            }
        }
    }

    private void FixedUpdate()
    {
        if(_timeCount >= _healingRate)
        {
            if(_healthToHeal.Count > 0)
            {
                _timeCount = 0;
                TryHeal(_healthToHeal, _amountToHeal);
            }            
        }

        _timeCount += Time.deltaTime;
    }

    private void TryAddHealthToList(Health health)
    {
        bool canBeAdded = true;

        foreach (var healthToHeal in _healthToHeal)
        {
            if (health == healthToHeal)
            {
                canBeAdded = false;
            }
        }

        if (canBeAdded == true)
        {
            _healthToHeal.Add(health);
        }
    }

    private void TryHeal(List<Health> health, int amountToHeal)
    {
        foreach (var item in health)
        {
            item.TryHeal(amountToHeal);
        }
    }
}
