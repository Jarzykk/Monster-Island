using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionsArmyPanel : MonoBehaviour
{
    [SerializeField] private MinionsTab _minionsTabTemplate;
    [SerializeField] private MinionsArmy _minionsArmy;
    [SerializeField] private int _minionsAmountToVisualizeTabs;

    private List<MinionsTab> _tabs = new List<MinionsTab>();
    private bool _tabsSetActive = false;
    private bool _tabsWasSetActive = false;

    private void OnEnable()
    {
        _minionsArmy.NewMinionAdded += OnNewMinionAdded;
    }

    private void OnDisable()
    {
        _minionsArmy.NewMinionAdded -= OnNewMinionAdded;
    }

    private void OnNewMinionAdded(Minion minion)
    {
        AddNewMinionsTab(minion);

        if (_tabsSetActive == false)
            if (_minionsArmy.MinionAmount >= _minionsAmountToVisualizeTabs)
                _tabsSetActive = true;

        if(_tabsWasSetActive == false && _tabsSetActive == true)
        {
            foreach (var tab in _tabs)
            {
                tab.gameObject.SetActive(true);
            }
        }

        _tabsWasSetActive = _tabsSetActive;
    }

    private void AddNewMinionsTab(Minion minion)
    {
        MinionsTab minionsTab = Instantiate(_minionsTabTemplate, transform);
        minionsTab.InstantiateMinion(minion);
        minionsTab.SetHealth(minion.GetComponent<Health>());
        _tabs.Add(minionsTab);

        if (_tabsSetActive == false)
            minionsTab.gameObject.SetActive(false);
    }
}
