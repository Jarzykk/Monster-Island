using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarSlider;

    private Health _health;

    public void SetHealthComponent(Health health)
    {
        _health = health;
        _health.HealthChanged += OnHealthChanged;
        _health.MinValueReached += OnDeath;
    }

    private void OnHealthChanged(int value, int maxValue)
    {
        _healthBarSlider.value = (float)value / maxValue;
    }

    private void OnDeath()
    {
        _health.HealthChanged -= OnHealthChanged;
        _health.MinValueReached -= OnDeath;
        Destroy(gameObject);
    }
}