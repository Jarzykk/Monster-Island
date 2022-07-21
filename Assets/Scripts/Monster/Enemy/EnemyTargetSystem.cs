using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetSystem : MonsterTargetSystem
{
    public override void TrySetTarget(Monster target)
    {
        if(target.TryGetComponent<Minion>(out Minion minion))
        {
            base.TrySetTarget(minion);
        }
    }
}
