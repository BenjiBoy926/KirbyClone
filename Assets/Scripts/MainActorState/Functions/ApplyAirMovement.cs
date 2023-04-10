using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAirMovement : MainActorStateFunction
{
    public ApplyAirMovement(MainActorState state) : base(state) { }
    public override void Update()
    {
        MainActor actor = _state.Actor;
        actor.Config.AirMovement.Move(actor.Rigidbody, actor.Input.Heading.x, 0);
    }
}
