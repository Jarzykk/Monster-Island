using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionTamer : MonoBehaviour
{
    [SerializeField] private GameObject _minionToTameTemplate;
    [SerializeField] private Enemy _enemy;

    private TamingUiElements _tamingUiElements;
    private Minion _minionToTame;

    private void OnEnable()
    {
        if (_minionToTameTemplate.TryGetComponent<Minion>(out Minion minion))
            _minionToTame = minion;
        else
            throw new System.Exception("Wrong argument");

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
        _tamingUiElements.StartTamingUi(_minionToTame);
    }

    private void Tame()
    {
        MinionsArmy playerMinionsArmy = FindObjectOfType<MinionsArmy>();
        playerMinionsArmy.AddMinionToArmy(_minionToTame);
    }
}
