using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsFallingWhenGroundLeft : KirbyStateFunction
{
    public SetIsFallingWhenGroundLeft(KirbyState state) : base(state) { }

    public override void OnEnable()
    {
        _state.Kirby.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        SetStateToFallingIfNeeded();
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
        SetStateToFallingIfNeeded();
    }
    private void SetStateToFallingIfNeeded()
    {
        if (!_state.Kirby.Contact.IsTouchingFloor)
        {
            _state.SetIntendedNextState(_state.Kirby.States.IsFalling);
        }
    }
}
