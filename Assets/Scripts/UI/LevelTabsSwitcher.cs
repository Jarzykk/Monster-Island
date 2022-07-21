using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTabsSwitcher : MonoBehaviour
{
    [SerializeField] private LevelTab _healthBarLevelTab;
    [SerializeField] private LevelTab _levelTabAboveMonster;
    [SerializeField] private HealthBarForScene _healthBar;

    private void OnEnable()
    {
        _healthBar.SetEnabled += OnHealthBarActivated;
        _healthBar.SetDisabled += OnHealthBarDeactivated;

        OnHealthBarDeactivated();
    }

    private void OnDisable()
    {
        _healthBar.SetEnabled -= OnHealthBarActivated;
        _healthBar.SetDisabled -= OnHealthBarDeactivated;
    }

    private void OnHealthBarActivated()
    {
        _healthBarLevelTab.gameObject.SetActive(true);
        _levelTabAboveMonster.gameObject.SetActive(false);
    }

    private void OnHealthBarDeactivated()
    {
        _healthBarLevelTab.gameObject.SetActive(false);
        _levelTabAboveMonster.gameObject.SetActive(true);
    }
}
