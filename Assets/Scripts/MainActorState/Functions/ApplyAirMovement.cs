using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAirMovement : MainActorStateFunction
{
    public ApplyAirMovement(MainActorState state) : base(state) { }
    public override void OnEnable()
    {

    }
    public override void OnDisable()
    {

    }
    public override void Update()
    {
        MainActor kirby = _state.Actor;
        kirby.Config.AirMovement.Move(kirby.Rigidbody, kirby.Heading.x, 0);
    }
    public override void NotifyHeadingSet()
    {

    }
    public override void NotifyActionTriggered(MainActorAction action)
    {

    }
}
