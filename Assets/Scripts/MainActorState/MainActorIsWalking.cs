using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorIsWalking : MainActorState
{
    private void Awake()
    {
        AddFunction(new SetIsFallingWhenGroundLeft(this));
        AddFunction(new SetStateOnActionTriggered(this, _actor.StateMachine.IsJumping, MainActorAction.StartJumping));
    }
    protected override void Update()
    {
        MainActorConfiguration config = _actor.Config;
        config.WalkingMovement.Move(_actor.Rigidbody, _actor.Input.Heading.x, 0);

        if (_actor.Input.Heading.x == 0)
        {
            _actor.Animator.SetAnimation(config.IdleAnimation, false);
        }
        else
        {
            _actor.Animator.SetAnimation(config.WalkingAnimation, false);
        }
    }
}
