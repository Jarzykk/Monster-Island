using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private HealthBarForScene _healthBar;

    private int _currentHealth;
    private bool _isAlive = true;

    public int CurrentHealth => _currentHealth;
    public int MaxValue => _maxHealth;
    public HealthBarForScene HealthBar => _healthBar;

    public event UnityAction MinValueReached;
    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TryHeal(int amountToHeal)
    {
        if(_currentHealth < _maxHealth && _currentHealth > 0)
        {
            if (amountToHeal <= 0)
                throw new System.Exception("Wrong argument");

            _currentHealth += amountToHeal;

            if (_currentHealth > _maxHealth)
                _currentHealth = _maxHealth;

            HealthChanged?.Invoke(_currentHealth, _maxHealth);
        }        
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0 && _currentHealth > 0)
        {
            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth, _maxHealth);

            if (_currentHealth <= 0 && _isAlive)
            {
                _isAlive = false;
                MinValueReached?.Invoke();
            }
        }   
    }
}
