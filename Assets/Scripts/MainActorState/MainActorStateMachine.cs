using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class MainActorStateMachine : MonoBehaviour
{
    [SerializeField]
    private MainActorIsWalking _isWalking;
    [SerializeField]
    private MainActorIsJumping _isJumping;
    [SerializeField]
    private MainActorIsFalling _isFalling;
    [SerializeField]
    private MainActorIsFloating _isFloating;
    [SerializeField]
    private MainActorIsSpittingAir _isSpittingAir;

    [SerializeField, ReadOnly]
    private MainActorState _previousState;
    [SerializeField, ReadOnly]
    private MainActorState _currentState;

    public MainActorIsWalking IsWalking => _isWalking;
    public MainActorIsJumping IsJumping => _isJumping;
    public MainActorIsFalling IsFalling => _isFalling;
    public MainActorIsFloating IsFloating => _isFloating;
    public MainActorIsSpittingAir IsSpittingAir => _isSpittingAir;

    private void Awake()
    {
        SetState(_isWalking);
    }
    private void Reset()
    {
        SetKirbyState(ref _isWalking);
        SetKirbyState(ref _isJumping);
        SetKirbyState(ref _isFalling);
        SetKirbyState(ref _isFloating);
        SetKirbyState(ref _isSpittingAir);
    }
    private void SetKirbyState<TState>(ref TState state)
        where TState : MainActorState
    {
        state = GetComponentInChildren<TState>(true);
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
    public void NotifyActionTriggered(MainActorAction action)
    {
        _currentState.NotifyActionTriggered(action);
    }
}
