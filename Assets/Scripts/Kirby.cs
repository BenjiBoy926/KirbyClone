using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Kirby : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private ColliderContact2D _contact;
    [SerializeField]
    private KirbyConfiguration _config;
    [SerializeField]
    private KirbyStateList _states;

    [SerializeField, ReadOnly]
    private KirbyState _previousState;
    [SerializeField, ReadOnly]
    private KirbyState _currentState;
    [SerializeField, ReadOnly]
    private Vector2Int _heading;

    public Rigidbody2D Rigidbody => _rigidbody;
    public ColliderContact2D Contact => _contact;
    public KirbyConfiguration Config => _config;
    public KirbyStateList States => _states;
    public KirbyState PreviousState => _previousState;
    public KirbyState CurrentState => _currentState;
    public Vector2Int Heading => _heading;

    private void Awake()
    {
        SetState(_states.IsWalking);
    }
    public void SetState(KirbyState state)
    {
        _previousState = _currentState;
        _currentState = state;

        if (_previousState != null)
        {
            _previousState.enabled = false;
        }
        if (_currentState != null)
        {
            _currentState.enabled = true;
        }
    }
    public void SetHeading(Vector2Int heading)
    {
        if (_heading != heading)
        {
            _heading = heading;
            if (_currentState != null)
            {
                _currentState.NotifyHeadingSet();
            }
        }
    }
    public void TriggerAction(KirbyAction action)
    {
        if (_currentState != null)
        {
            _currentState.NotifyActionTriggered(action);
        }
    }
}
