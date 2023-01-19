using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevelTabsActivateOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        LevelTabsEnabler enabler = other.GetComponentInChildren(typeof(LevelTabsEnabler), true) as LevelTabsEnabler;

        if (enabler != null)
            enabler.EnableLevelTabs();
    }
}
