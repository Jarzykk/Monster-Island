using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionTamer : MonoBehaviour
{
    [SerializeField] private Minion _minionToTameTemplate;
    [SerializeField] private Enemy _enemy;

    private TamingUiElements _tamingUiElements;

    private void OnEnable()
    {
        _tamingUiElements = FindObjectOfType<TamingUiElements>();

        _enemy.Died += OnMinHealthValueReached;
        _tamingUiElements.SpawnButtonPressed += TameMinion;
    }    

    private void OnDisable()
    {
        _enemy.Died -= OnMinHealthValueReached;
        _tamingUiElements.SpawnButtonPressed -= TameMinion;
    }

    private void TameMinion()
    {
        Tame();
        Destroy(gameObject);
    }

    private void OnMinHealthValueReached()
    {
        gameObject.transform.parent = null;
        _tamingUiElements.StartTamingUi(_minionToTameTemplate);
    }

    private void Tame()
    {
        MinionsArmy playerMinionsArmy = FindObjectOfType<MinionsArmy>();
        playerMinionsArmy.AddMinionToArmy(_minionToTameTemplate);
    }
}
