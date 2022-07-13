using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionsTab : MonoBehaviour
{
    [SerializeField] private Transform _minionUiPosition;
    [SerializeField] private int _uiLayerNumber;
    [SerializeField] private Vector3 _minionUiScale;
    [SerializeField] private HealthBar _healthBar;

    private Minion _minionToTame;

    public void InstantiateMinion(Minion minionTemplate)
    {
        _minionToTame = Instantiate(minionTemplate, _minionUiPosition);
        _minionToTame.DisableComponentsForUI();
        _minionToTame.DisableAnimations();
        SetMinionsLayersToUi(_minionToTame, _uiLayerNumber);
        _minionToTame.transform.localScale = _minionUiScale;
    }

    public void SetHealth(Health health)
    {
        _healthBar.SetHealthComponent(health);
    }

    private void SetMinionsLayersToUi(Minion minion, int layerNumber)
    {
        foreach (Transform childObject in minion.GetComponentsInChildren<Transform>(true))
        {
            childObject.gameObject.layer = layerNumber;
        }
    }
}
