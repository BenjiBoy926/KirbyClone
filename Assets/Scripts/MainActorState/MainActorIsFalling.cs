using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorIsFalling : MainActorState
{
    private void Awake()
    {
        AddFunction(new SetStateOnActionTriggered(this, _actor.StateMachine.IsFloating, MainActorAction.StartJumping));
        AddFunction(new SetIsWalkingWhenGroundReached(this));
        AddFunction(new ApplyAirMovement(this));
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        _actor.Animator.SetAnimation(_actor.Config.FallingAnimation, true);
    }
}
