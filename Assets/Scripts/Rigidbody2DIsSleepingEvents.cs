using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Rigidbody2DIsSleepingEvents : MonoBehaviour
{
    public delegate void IsSleepingDelegate(bool isSleeping);

    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField, ReadOnly]
    private bool _previousIsSleeping;

    private IsSleepingDelegate _isSleepingChanged = delegate { };
    public event IsSleepingDelegate IsSleepingChanged
    {
        add
        {
            _isSleepingChanged += value;
            enabled = ShouldBeEnabled();
        }
        remove
        {
            _isSleepingChanged -= value;
            enabled = ShouldBeEnabled();
        }
    }

    public bool IsSleeping => _rigidbody.IsSleeping();

    private void Update()
    {
        bool currentIsSleeping = _rigidbody.IsSleeping();
        if (currentIsSleeping != _previousIsSleeping)
        {
            _previousIsSleeping = currentIsSleeping;
            _isSleepingChanged(currentIsSleeping);
        }   
    }
    private bool ShouldBeEnabled()
    {
        return _isSleepingChanged.GetInvocationList().Length > 0;
    }
}
