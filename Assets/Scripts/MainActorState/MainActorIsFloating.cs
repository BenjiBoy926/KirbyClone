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
        _actor.Animator.OnFrameEntered += Animator_OnFrameEntered;
        StartFloat();
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _actor.Rigidbody.gravityScale = _gravityBeforeState;
        _actor.Contact.IsTouchingFloorChanged -= Contact_IsTouchingFloorChanged;
        _actor.Animator.OnFrameEntered -= Animator_OnFrameEntered;
    }
    protected override void Update()
    {
        base.Update();
        _actor.Config.FloatingMovement.Move(_actor.Rigidbody, _actor.Input.Heading.x, 0);
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        if (action == MainActorAction.StartJumping)
        {
            StartFloat();
        }
        if (action == MainActorAction.StartAttacking)
        {
            SetIntendedNextState(_actor.StateMachine.IsSpittingAir);
        }
    }
    private void StartFloat()
    {
        _actor.Animator.SetAnimation(_actor.Config.FloatingAnimation, true);
    }
    private void ApplyFloatVelocity()
    {
        _actor.Rigidbody.SetVelocityY(_actor.Config.FloatSpeed);
    }
    private void Contact_IsTouchingFloorChanged(bool isTouching)
    {
        if (isTouching)
        {
            SetIntendedNextState(_actor.StateMachine.IsSpittingAir);
        }
    }
    private void Animator_OnFrameEntered(SpriteFrame frame)
    {
        if (frame.IsActionFrame)
        {
            ApplyFloatVelocity();
        }
    }
}
