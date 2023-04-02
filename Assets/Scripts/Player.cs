using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private MainActor _actor;
    [SerializeField]
    private PlayerInput _input;
    [SerializeField]
    private string _headingActionName = "Heading";
    [SerializeField]
    private string _jumpActionName = "Jump";
    [SerializeField]
    private string _attackActionName = "Attack";

    private void Awake()
    {
        _input.onActionTriggered += Input_onActionTriggered;
    }
    private void OnDestroy()
    {
        _input.onActionTriggered -= Input_onActionTriggered;
    }
    private void Input_onActionTriggered(InputAction.CallbackContext obj)
    {
        InputAction action = obj.action;
        if (action == null)
        {
            return;
        }
        
        if (action.name == _headingActionName)
        {
            Vector2 headingFloat = obj.ReadValue<Vector2>();
            Vector2Int heading = Vector2Int.zero;
            heading.x = Mathf.RoundToInt(headingFloat.x);
            heading.y = Mathf.RoundToInt(headingFloat.y);
            _actor.SetHeading(heading);
        }
        if (action.name == _jumpActionName)
        {
            TriggerAction(obj, MainActorAction.StartJumping, MainActorAction.StopJumping);
        }
        if (action.name == _attackActionName)
        {
            TriggerAction(obj, MainActorAction.StartAttacking, MainActorAction.StopAttacking);
        }
    }

    private void TriggerAction(InputAction.CallbackContext context, MainActorAction actionStart, MainActorAction actionStop)
    {
        if (context.performed)
        {
            _actor.TriggerAction(actionStart);
        }
        else if (context.canceled)
        {
            _actor.TriggerAction(actionStop);
        }
    }
}
