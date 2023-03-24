using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class LazyComponent<TComponent> : Lazy<TComponent>
    where TComponent : Component
{
    [SerializeField]
    protected GameObject _self;

    public GameObject Self
    {
        get { return _self; }
        set { _self = value; }
    }

    protected abstract override TComponent LoadValue();
}
