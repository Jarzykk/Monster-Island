using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionTargetSystem : MonsterTargetSystem
{
    public override void TrySetTarget(Monster target)
    {
        if(target.TryGetComponent<Enemy>(out Enemy enemy))
        {
            base.TrySetTarget(enemy);
        }
    }
}
