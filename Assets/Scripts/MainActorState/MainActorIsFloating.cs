using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorIsFloating : MainActorState
{
    [SerializeField, ReadOnly]
    private float _gravityBeforeState;

    protected override void OnEnable()
    {
        base.OnEnable();
        _gravityBeforeState = _actor.Rigidbody.gravityScale;
        _actor.Rigidbody.gravityScale = _actor.Config.FloatingGravity;
        _actor.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        Float();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _actor.Rigidbody.gravityScale = _gravityBeforeState;
        _actor.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
    }
    protected override void Update()
    {
        base.Update();
        _actor.Config.FloatingMovement.Move(_actor.Rigidbody, _actor.Heading.x, 0);
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        if (action == MainActorAction.StartJumping)
        {
            Float();
        }
        if (action == MainActorAction.StartAttacking)
        {
            Vector2 velocity = _actor.Rigidbody.velocity;
            velocity.y = 0;
            _actor.Rigidbody.velocity = velocity;
            SetIntendedNextState(_actor.States.IsFalling);
        }
    }
    private void Float()
    {
        Vector2 velocity = _actor.Rigidbody.velocity;
        velocity.y = _actor.Config.FloatSpeed;
        _actor.Rigidbody.velocity = velocity;
    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        if (isTouching)
        {
            SetIntendedNextState(_actor.States.IsWalking);
        }
    }
}
