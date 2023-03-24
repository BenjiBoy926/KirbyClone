using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsWalkingWhenGroundReached : KirbyStateFunction
{
    public SetIsWalkingWhenGroundReached(KirbyState state) : base(state) { }
    public override void OnEnable()
    {
        _state.Kirby.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        SetStateToWalkingIfNeeded();
    }
    public override void OnDisable()
    {
        _state.Kirby.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
    }
    public override void Update()
    {

    }
    public override void NotifyHeadingSet()
    {

    }
    public override void NotifyActionTriggered(KirbyAction action)
    {

    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        SetStateToWalkingIfNeeded();
    }
    private void SetStateToWalkingIfNeeded()
    {
        if (_state.Kirby.Contact.IsTouchingFloor)
        {
            _state.SetIntendedNextState(_state.Kirby.States.IsWalking);
        }
    }
}
