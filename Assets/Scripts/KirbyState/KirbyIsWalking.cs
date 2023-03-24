using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyIsWalking : KirbyState
{
    private void Awake()
    {
        AddFunction(new SetIsFallingWhenGroundLeft(this));
        AddFunction(new SetIsJumpingWhenJumpActionTriggered(this));
    }
    protected override void Update()
    {
        KirbyConfiguration config = _kirby.Config;
        config.WalkingMovement.Move(_kirby.Rigidbody, _kirby.Heading.x, 0);
    }
}
