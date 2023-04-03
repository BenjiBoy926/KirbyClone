using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorIsJumping : MainActorState
{
    [SerializeField, ReadOnly]
    private bool _hasStartedActionFrame = false;

    private void Awake()
    {
        AddFunction(new ApplyAirMovement(this));
        AddFunction(new SetStateOnActionTriggered(this, _actor.States.IsFloating, MainActorAction.StartJumping));
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        _hasStartedActionFrame = false;
        _actor.Animator.SetAnimation(_actor.Config.JumpingAnimation, true);
        _actor.Animator.OnFrameEntered += Animator_OnFrameEntered;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        _actor.Animator.OnFrameEntered -= Animator_OnFrameEntered;
    }
    protected override void Update()
    {
        base.Update();
        if (!_hasStartedActionFrame)
        {
            return;
        }

        MainActorConfiguration config = _actor.Config;
        Rigidbody2D rb = _actor.Rigidbody;
        rb.SetVelocityY(config.JumpSpeed);

        if (TimeSpentInState > config.JumpTime)
        {
            SetIntendedNextState(_actor.States.IsFalling);
        }
    }
    public override void NotifyActionTriggered(MainActorAction action)
    {
        if (action == MainActorAction.StopJumping)
        {
            SetIntendedNextState(_actor.States.IsFalling);
        }
    }
    private void Animator_OnFrameEntered(SpriteFrame frame)
    {
        if (frame.IsActionFrame)
        {
            _hasStartedActionFrame = true;
        }
    }
}
