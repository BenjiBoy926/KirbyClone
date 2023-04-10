using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorInput : MonoBehaviour
{
    [SerializeField]
    private MainActor _actor;

    [SerializeField, ReadOnly]
    private Vector2Int _heading;

    public Vector2Int Heading => _heading;

    public void SetHeading(Vector2Int heading)
    {
        if (_heading != heading)
        {
            _heading = heading;
            _actor.Animator.FlipSprite(_heading.x);
        }
    }
    public void TriggerAction(MainActorAction action)
    {
        _actor.StateMachine.NotifyActionTriggered(action);
    }
}
