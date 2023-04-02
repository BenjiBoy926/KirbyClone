using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetStateOnActionTriggered : MainActorStateFunction
{
    private MainActorState _nextState;
    private MainActorAction _action;

    public SetStateOnActionTriggered(MainActorState state, MainActorState nextState, MainActorAction action) 
        : base(state) 
    { 
        _nextState = nextState;
        _action = action;
    }

    public override void OnEnable()
    {

    }
    public override void OnDisable()
    {

    }
    public override void Update()
    {

    }
    public override void NotifyHeadingSet()
    {

    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        if (_action == action)
        {
            _state.SetIntendedNextState(_nextState);
        }
    }
}
