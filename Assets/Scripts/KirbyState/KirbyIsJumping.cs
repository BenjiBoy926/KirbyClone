using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyIsJumping : KirbyState
{
    private void Awake()
    {
        AddFunction(new ApplyAirMovement(this));
        AddFunction(new SetIsFloatingWhenJumpActionTriggered(this));
    }
    protected override void Update()
    {
        base.Update();
        KirbyConfiguration config = _kirby.Config;
        Rigidbody2D rb = _kirby.Rigidbody;
        Vector2 velocity = rb.velocity;
        velocity.y = config.JumpSpeed;
        rb.velocity = velocity;

        if (TimeSpentInState > config.JumpTime)
        {
            SetIntendedNextState(_kirby.States.IsFalling);
        }
    }
    public override void NotifyHeadingSet()
    {
        
    }
    public override void NotifyActionTriggered(KirbyAction action)
    {
        if (action == KirbyAction.StopJumping)
        {
            SetIntendedNextState(_kirby.States.IsFalling);
        }
    }
}
