using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Hitbox : MonoBehaviour
{
    [System.Serializable]
    public struct HitData
    {
        public Hurtbox _hurtbox;
        public float _timeOfLastHit;

        public float TimeSinceLastHit => Time.time - _timeOfLastHit;

        public HitData(Hurtbox hurtbox, float timeOfLastHit)
        {
            _hurtbox = hurtbox;
            _timeOfLastHit = timeOfLastHit;
        }
    }

    [SerializeField]
    private int _strength = 1;
    [SerializeField]
    private bool _hitMultipleTimes = false;
    [SerializeField, EnableIf(nameof(_hitMultipleTimes))]
    private float _delayBetweenHits = 0.4f;
    
    private Dictionary<Collider2D, HitData> _hitDatas = new Dictionary<Collider2D, HitData>();

    public int Strength => _strength;

    public event DamageDelegate OnHit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDealDamage(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TryDealDamage(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _hitDatas.Remove(collision);
    }

    private void TryDealDamage(Collider2D collider)
    {
        if (!IsAllowedToHit(collider))
        {
            return;
        }

        Hurtbox hurtbox = collider.GetComponent<Hurtbox>();
        if (hurtbox == null)
        {
            return;
        }

        DealDamage(hurtbox);
        if (_hitMultipleTimes)
        {
            _hitDatas[collider] = new HitData(hurtbox, Time.time);
        }
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
    public bool IsAllowedToHit(Collider2D collider)
    {
        return !_hitMultipleTimes || !_hitDatas.ContainsKey(collider) || _hitDatas[collider].TimeSinceLastHit >= _delayBetweenHits;
    }
}
