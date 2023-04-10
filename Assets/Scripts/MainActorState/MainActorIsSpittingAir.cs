using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorIsSpittingAir : MainActorState
{
    [SerializeField, ReadOnly]
    private float _gravityBeforeState;

    private void Awake()
    {
        AddFunction(new ApplyAirMovement(this));
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        _gravityBeforeState = _actor.Rigidbody.gravityScale;
        _actor.Rigidbody.gravityScale = 0;
        _actor.Rigidbody.SetVelocityY(0);
        _actor.Animator.OnFrameEntered += Animator_OnFrameEntered;
        _actor.Animator.OnAnimationEnded += Animator_OnAnimationEnded;
        _actor.Animator.SetAnimation(_actor.Config.AirSpitAnimation, true);
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _actor.Rigidbody.gravityScale = _gravityBeforeState;
        _actor.Animator.OnFrameEntered -= Animator_OnFrameEntered;
        _actor.Animator.OnAnimationEnded -= Animator_OnAnimationEnded;
    }
    private void Animator_OnFrameEntered(SpriteFrame frame)
    {
        if (frame.IsActionFrame)
        {
            // Spit out the air bubble
        }
    }
    private void Animator_OnAnimationEnded()
    {
        if (_actor.Contact.IsTouchingFloor)
        {
            SetIntendedNextState(_actor.StateMachine.IsWalking);
        }
        else
        {
            SetIntendedNextState(_actor.StateMachine.IsFalling);
        }
    }
}
