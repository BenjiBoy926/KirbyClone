using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LazyComponentOnSelf<TComponent> : LazyComponent<TComponent>
    where TComponent : Component
{
    protected override TComponent LoadValue()
    {
        return _self.GetComponent<TComponent>();
    }
}
