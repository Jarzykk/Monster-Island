using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarForScene : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _health;
    [SerializeField] private Monster _monster;
    public Health Health => _health;
    public Monster Monster => _monster;

    public event UnityAction SetEnabled;
    public event UnityAction SetDisabled;

    private void Awake()
    {
        DeactivateHealthBar();
    }

    private void OnEnable()
    {
        Monster.EnteredBattleState += OnBattleStateActivated;
        Monster.LeftBattleState += DeactivateHealthBar;
        Health.HealthChanged += OnValueChanged;
        Health.MinValueReached += DeactivateHealthBar;
    }

    private void OnDisable()
    {
        Monster.EnteredBattleState -= OnBattleStateActivated;
        Monster.LeftBattleState -= DeactivateHealthBar;
        Health.HealthChanged -= OnValueChanged;
        Health.MinValueReached -= DeactivateHealthBar;
    }

    public void OnValueChanged()
    {
        _slider.value = (float)_health.CurrentHealth / _health.MaxHealth;
    }

    public void OnBattleStateActivated()
    {
        if (_health.CurrentHealth > 0)
            ActivateHealthBar();
    }

    public void DeactivateHealthBar()
    {
        _slider.gameObject.SetActive(false);
        SetDisabled?.Invoke();
    }

    public void ActivateHealthBar()
    {
        _slider.gameObject.SetActive(true);
        SetEnabled?.Invoke();
    }
}
