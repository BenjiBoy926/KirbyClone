using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorIsFalling : MainActorState
{
    private void Awake()
    {
        AddFunction(new SetStateOnActionTriggered(this, _actor.States.IsFloating, MainActorAction.StartJumping));
        AddFunction(new SetIsWalkingWhenGroundReached(this));
        AddFunction(new ApplyAirMovement(this));
    }
}
