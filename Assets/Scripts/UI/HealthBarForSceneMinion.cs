using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarForSceneMinion : HealthBarForScene
{
    [SerializeField] private HealingSpotOnTriggerFinder _healingSpotFinder;

    private void OnEnable()
    {
        _healingSpotFinder.EnteredHealingSpot += ActivateHealthBar;
        _healingSpotFinder.LeftHealingSpot += DeactivateHealthBar;
        Monster.EnteredBattleState += OnBattleStateActivated;
        Monster.LeftBattleState += DeactivateHealthBar;
        Health.HealthChanged += OnValueChanged;
        Health.MinValueReached += DeactivateHealthBar;
    }

    private void OnDisable()
    {
        _healingSpotFinder.EnteredHealingSpot += ActivateHealthBar;
        _healingSpotFinder.LeftHealingSpot += DeactivateHealthBar;
        Monster.EnteredBattleState -= OnBattleStateActivated;
        Monster.LeftBattleState -= DeactivateHealthBar;
        Health.HealthChanged -= OnValueChanged;
        Health.MinValueReached -= DeactivateHealthBar;
    }
}
