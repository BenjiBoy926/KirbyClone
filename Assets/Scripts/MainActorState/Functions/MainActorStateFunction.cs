using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MainActorStateFunction
{
    protected MainActorState _state;

    public MainActorStateFunction(MainActorState state)
    {
        _state = state;
    }

    public virtual void OnEnable() { }
    public virtual void OnDisable() { }
    public virtual void Update() { }
    public virtual void NotifyActionTriggered(MainActorAction action) { }
}
