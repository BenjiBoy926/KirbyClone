using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsFallingWhenGroundLeft : MainActorStateFunction
{
    public SetIsFallingWhenGroundLeft(MainActorState state) : base(state) { }

    public override void OnEnable()
    {
        _state.Actor.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        SetStateToFallingIfNeeded();
    }
    public override void OnDisable()
    {
        _state.Actor.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
    }
    public override void Update()
    {
        
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        
    }

    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        SetStateToFallingIfNeeded();
    }
    private void SetStateToFallingIfNeeded()
    {
        if (!_state.Actor.Contact.IsTouchingFloor)
        {
            _state.SetIntendedNextState(_state.Actor.States.IsFalling);
        }
    }
}
