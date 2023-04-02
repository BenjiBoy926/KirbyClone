using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorIsJumping : MainActorState
{
    private void Awake()
    {
        AddFunction(new ApplyAirMovement(this));
        AddFunction(new SetStateOnActionTriggered(this, _actor.States.IsFloating, MainActorAction.StartJumping));
    }
    protected override void Update()
    {
        base.Update();
        MainActorConfiguration config = _actor.Config;
        Rigidbody2D rb = _actor.Rigidbody;
        Vector2 velocity = rb.velocity;
        velocity.y = config.JumpSpeed;
        rb.velocity = velocity;

        if (TimeSpentInState > config.JumpTime)
        {
            SetIntendedNextState(_actor.States.IsFalling);
        }
    }
    public override void NotifyHeadingSet()
    {
        
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        if (action == MainActorAction.StopJumping)
        {
            SetIntendedNextState(_actor.States.IsFalling);
        }
    }
}
