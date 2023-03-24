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
            if (obj.performed)
            {
                _kirby.TriggerAction(KirbyAction.StartJumping);
            }
            else if (obj.canceled)
            {
                _kirby.TriggerAction(KirbyAction.StopJumping);
            }
        }
    }
}
