using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LazyComponentInParent<TComponent> : LazyComponent<TComponent>
    where TComponent : Component
{
    protected override TComponent LoadValue()
    {
        return _self.GetComponentInParent<TComponent>();
    }
}
