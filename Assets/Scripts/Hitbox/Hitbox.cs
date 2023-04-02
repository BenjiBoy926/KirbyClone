using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private int _strength = 1;

    public int Strength => _strength;

    public event DamageDelegate OnHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDealDamage(collision);
    }
    private void TryDealDamage(Collider2D collider)
    {
        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        if (hurtbox == null)
        {
            return;
        }
        DealDamage(hurtbox);
    }
    public void DealDamage(Hurtbox hurtbox)
    {
        if (hurtbox == null)
        {
            return;
        }
        int adjustedDamage = hurtbox.ReceiveDamage(this);
        OnHit(this, hurtbox, adjustedDamage);
    }
}
