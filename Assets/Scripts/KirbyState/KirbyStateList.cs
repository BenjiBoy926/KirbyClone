using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KirbyStateList : MonoBehaviour
{
    [SerializeField]
    private KirbyIsWalking _isWalking;
    [SerializeField]
    private KirbyIsJumping _isJumping;
    [SerializeField]
    private KirbyIsFalling _isFalling;
    
    public KirbyIsWalking IsWalking => _isWalking;
    public KirbyIsJumping IsJumping => _isJumping;
    public KirbyIsFalling IsFalling => _isFalling;

    private void Reset()
    {
        SetKirbyState(ref _isWalking);
        SetKirbyState(ref _isJumping);
        SetKirbyState(ref _isFalling);
    }
    private void SetKirbyState<TState>(ref TState state)
    {
        state = GetComponent<TState>();
    }
}
