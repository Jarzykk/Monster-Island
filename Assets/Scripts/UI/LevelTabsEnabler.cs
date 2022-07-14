using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTabsEnabler : MonoBehaviour
{
    [SerializeField] private LevelTabs _levelTabs;

    private void Start()
    {
        DisableLevelTabs();
    }

    public void EnableLevelTabs()
    {
        _levelTabs.gameObject.SetActive(true);
    }

    public void DisableLevelTabs()
    {
        _levelTabs.gameObject.SetActive(false);
    }
}
