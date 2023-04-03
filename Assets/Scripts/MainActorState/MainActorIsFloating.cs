using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorIsFloating : MainActorState
{
    [SerializeField, ReadOnly]
    private float _gravityBeforeState;
    [SerializeField, ReadOnly]
    private bool _isSpittingAir = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        _gravityBeforeState = _actor.Rigidbody.gravityScale;
        _isSpittingAir = false;
        _actor.Rigidbody.gravityScale = _actor.Config.FloatingGravity;
        _actor.Contact.IsTouchingFloorChanged += Contact_IsTouchingFloorChanged;
        _actor.Animator.OnFrameEntered += Animator_OnFrameEntered;
        _actor.Animator.OnAnimationEnded += Animator_OnAnimationEnded;
        StartFloat();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _actor.Rigidbody.gravityScale = _gravityBeforeState;
        _actor.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
        _actor.Animator.OnFrameExited -= Animator_OnFrameEntered;
        _actor.Animator.OnAnimationEnded -= Animator_OnAnimationEnded;
    }
    protected override void Update()
    {
        base.Update();
        _actor.Config.FloatingMovement.Move(_actor.Rigidbody, _actor.Heading.x, 0);
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        // NOTE: the spitting air should be a separate state
        if (action == MainActorAction.StartJumping && !_isSpittingAir)
        {
            StartFloat();
        }
        if (action == MainActorAction.StartAttacking)
        {
            StartAirSpit();
        }
    }
    private void StartFloat()
    {
        _actor.Animator.SetAnimation(_actor.Config.FloatingAnimation, true);
    }
    private void StartAirSpit()
    {
        _isSpittingAir = true;
        _actor.Rigidbody.gravityScale = 0;
        _actor.Rigidbody.velocity = _actor.Rigidbody.velocity.SetY(0);
        _actor.Animator.SetAnimation(_actor.Config.AirSpitAnimation, true);
    }
    private void ApplyFloatVelocity()
    {
        _actor.Rigidbody.velocity = _actor.Rigidbody.velocity.SetY(_actor.Config.FloatSpeed);
    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        if (isTouching)
        {
            StartAirSpit();
        }
    }
    private void Animator_OnFrameEntered(SpriteFrame frame)
    {
        if (frame.IsActionFrame)
        {
            if (!_isSpittingAir)
            {
                ApplyFloatVelocity();
            }
            else
            {
                // Spit out the air bubble
            }
        }
    }
    private void Animator_OnAnimationEnded()
    {
        if (_isSpittingAir)
        {
            if (_actor.Contact.IsTouchingFloor)
            {
                SetIntendedNextState(_actor.States.IsWalking);
            }
            else
            {
                SetIntendedNextState(_actor.States.IsFalling);
            }
        }
    }
}
