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

    public abstract void OnEnable();
    public abstract void OnDisable();
    public abstract void Update();
    public abstract void NotifyActionTriggered(MainActorAction action);
}
