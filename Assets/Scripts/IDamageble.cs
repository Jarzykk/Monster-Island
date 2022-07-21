using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    int Damage { get; }

    void DealDamage(Health opponent);
}
