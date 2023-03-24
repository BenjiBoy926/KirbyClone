using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KirbyStateFunction
{
    protected KirbyState _state;

    public KirbyStateFunction(KirbyState state)
    {
        _state = state;
    }

    public abstract void OnEnable();
    public abstract void OnDisable();
    public abstract void Update();
    public abstract void NotifyHeadingSet();
    public abstract void NotifyActionTriggered(KirbyAction action);
}
