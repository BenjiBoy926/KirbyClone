using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorIsWalking : MainActorState
{
    private void Awake()
    {
        AddFunction(new SetIsFallingWhenGroundLeft(this));
        AddFunction(new SetStateOnActionTriggered(this, _actor.States.IsJumping, MainActorAction.StartJumping));
    }
    protected override void Update()
    {
        MainActorConfiguration config = _actor.Config;
        config.WalkingMovement.Move(_actor.Rigidbody, _actor.Heading.x, 0);
    }
}
