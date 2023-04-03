using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainActorStateList : MonoBehaviour
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
    
    public MainActorIsWalking IsWalking => _isWalking;
    public MainActorIsJumping IsJumping => _isJumping;
    public MainActorIsFalling IsFalling => _isFalling;
    public MainActorIsFloating IsFloating => _isFloating;
    public MainActorIsSpittingAir IsSpittingAir => _isSpittingAir;

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
        state = GetComponent<TState>();
    }
}
