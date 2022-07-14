using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Minion : Monster
{
    [SerializeField] private string _minonsTypeName;
    [SerializeField] private ComponentsDisabler _disabler;
    private Player _player;

    public Player Player => _player;
    public string MinionsTypeName => _minonsTypeName;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void DisableComponentsForUI()
    {
        _disabler.DisableComponentsforUi();
    }

    public void DisableAnimations()
    {
        _disabler.DisableAnimations();
    }
}
