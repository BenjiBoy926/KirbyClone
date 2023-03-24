using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyIsFalling : KirbyState
{
    private void Awake()
    {
        AddFunction(new SetIsFloatingWhenJumpActionTriggered(this));
        AddFunction(new SetIsWalkingWhenGroundReached(this));
        AddFunction(new ApplyAirMovement(this));
    }
}
