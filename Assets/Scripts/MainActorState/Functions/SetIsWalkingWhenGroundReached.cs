using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsWalkingWhenGroundReached : MainActorStateFunction
{
    public SetIsWalkingWhenGroundReached(MainActorState state) : base(state) { }
    public override void OnEnable()
    {
        _state.Actor.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        SetStateToWalkingIfNeeded();
    }
    public override void OnDisable()
    {
        _state.Actor.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        SetStateToWalkingIfNeeded();
    }
    private void SetStateToWalkingIfNeeded()
    {
        if (_state.Actor.Contact.IsTouchingFloor)
        {
            _state.SetIntendedNextState(_state.Actor.StateMachine.IsWalking);
        }
    }
}
