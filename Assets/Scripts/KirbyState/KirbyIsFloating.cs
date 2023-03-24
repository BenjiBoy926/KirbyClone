using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class KirbyIsFloating : KirbyState
{
    [SerializeField, ReadOnly]
    private float _gravityBeforeState;

    protected override void OnEnable()
    {
        base.OnEnable();
        _gravityBeforeState = _kirby.Rigidbody.gravityScale;
        _kirby.Rigidbody.gravityScale = _kirby.Config.FloatingGravity;
        _kirby.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        Float();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _kirby.Rigidbody.gravityScale = _gravityBeforeState;
        _kirby.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
    }
    protected override void Update()
    {
        base.Update();
        _kirby.Config.FloatingMovement.Move(_kirby.Rigidbody, _kirby.Heading.x, 0);
    }
    public override void NotifyActionTriggered(KirbyAction action)
    {
        if (action == KirbyAction.StartJumping)
        {
            Float();
        }
        if (action == KirbyAction.StartAttacking)
        {
            Vector2 velocity = _kirby.Rigidbody.velocity;
            velocity.y = 0;
            _kirby.Rigidbody.velocity = velocity;
            SetIntendedNextState(_kirby.States.IsFalling);
        }
    }
    private void Float()
    {
        Vector2 velocity = _kirby.Rigidbody.velocity;
        velocity.y = _kirby.Config.FloatSpeed;
        _kirby.Rigidbody.velocity = velocity;
    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        if (isTouching)
        {
            SetIntendedNextState(_kirby.States.IsWalking);
        }
    }
}
