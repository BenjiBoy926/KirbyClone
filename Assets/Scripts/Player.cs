using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Kirby _kirby;
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
            _kirby.SetHeading(heading);
        }
        if (action.name == _jumpActionName)
        {
            TriggerAction(obj, KirbyAction.StartJumping, KirbyAction.StopJumping);
        }
        if (action.name == _attackActionName)
        {
            TriggerAction(obj, KirbyAction.StartAttacking, KirbyAction.StopAttacking);
        }
    }

    private void TriggerAction(InputAction.CallbackContext context, KirbyAction actionStart, KirbyAction actionStop)
    {
        if (context.performed)
        {
            _kirby.TriggerAction(actionStart);
        }
        else if (context.canceled)
        {
            _kirby.TriggerAction(actionStop);
        }
    }
}
