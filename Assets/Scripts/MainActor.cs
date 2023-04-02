using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActor : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private ColliderContact2D _contact;
    [SerializeField]
    private MainActorConfiguration _config;
    [SerializeField]
    private MainActorStateList _states;
    [SerializeField]
    private SpriteAnimator _animator;

    [SerializeField, ReadOnly]
    private MainActorState _previousState;
    [SerializeField, ReadOnly]
    private MainActorState _currentState;
    [SerializeField, ReadOnly]
    private Vector2Int _heading;

    public Rigidbody2D Rigidbody => _rigidbody;
    public ColliderContact2D Contact => _contact;
    public MainActorConfiguration Config => _config;
    public MainActorStateList States => _states;
    public SpriteAnimator Animator => _animator;
    public MainActorState PreviousState => _previousState;
    public MainActorState CurrentState => _currentState;
    public Vector2Int Heading => _heading;

    private void Awake()
    {
        SetState(_states.IsWalking);
    }
    public void SetState(MainActorState state)
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
            if (_animator != null)
            {
                _animator.FlipSpriteOnHorizontalInput(_heading.x);
            }
        }
    }
    public void TriggerAction(MainActorAction action)
    {
        if (_currentState != null)
        {
            _currentState.NotifyActionTriggered(action);
        }
    }
}
