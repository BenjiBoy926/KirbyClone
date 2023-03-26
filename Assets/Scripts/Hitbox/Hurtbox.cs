using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField]
    private int _vulnerability = 1;

    public event DamageDelegate OnHurt;

    public int ReceiveDamage(Hitbox hitbox)
    {
        if (hitbox == null)
        {
            return 0;
        }
        int adjustedDamage = GetAdjustedDamage(hitbox);
        OnHurt(hitbox, this, adjustedDamage);
        return adjustedDamage;
    }
    public int GetAdjustedDamage(Hitbox hitbox)
    {
        if (hitbox == null)
        {
            return 0;
        }
        return hitbox.Strength * _vulnerability;
    }
}
