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
        _amountToHeal = Mathf.Clamp(_amountToHeal, 1, int.MaxValue);

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
        if (_healthToHeal.Contains(health) == false)
            _healthToHeal.Add(health);
    }

    private void TryHeal(List<Health> health, int amountToHeal)
    {
        foreach (var item in health)
        {
            item.TryHeal(amountToHeal);
        }
    }
}
