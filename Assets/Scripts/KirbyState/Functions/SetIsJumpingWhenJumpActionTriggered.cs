using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetIsJumpingWhenJumpActionTriggered : KirbyStateFunction
{
    public SetIsJumpingWhenJumpActionTriggered(KirbyState state) : base(state) { }
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
    public override void NotifyActionTriggered(KirbyAction action)
    {
        if (action == KirbyAction.StartJumping)
        {
            _state.SetIntendedNextState(_state.Kirby.States.IsJumping);
        }
    }
}
