using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyAirMovement : KirbyStateFunction
{
    public ApplyAirMovement(KirbyState state) : base(state) { }
    public override void OnEnable()
    {

    }
    public override void OnDisable()
    {

    }
    public override void Update()
    {
        Kirby kirby = _state.Kirby;
        kirby.Config.AirMovement.Move(kirby.Rigidbody, kirby.Heading.x, 0);
    }
    public override void NotifyHeadingSet()
    {

    }
    public override void NotifyActionTriggered(KirbyAction action)
    {

    }
}
