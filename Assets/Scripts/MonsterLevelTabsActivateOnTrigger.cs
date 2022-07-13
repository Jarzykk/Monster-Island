using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLevelTabsActivateOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponentInChildren<LevelTabsEnabler>())
        {
            other.GetComponentInChildren<LevelTabsEnabler>().EnableLevelTabs();
        }
    }
}
