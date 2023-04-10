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
    private MainActorStateMachine _stateMachine;
    [SerializeField]
    private SpriteAnimator _animator;
    [SerializeField]
    private MainActorInput _input;

    public Rigidbody2D Rigidbody => _rigidbody;
    public ColliderContact2D Contact => _contact;
    public MainActorConfiguration Config => _config;
    public MainActorStateMachine StateMachine => _stateMachine;
    public SpriteAnimator Animator => _animator;
    public MainActorInput Input => _input;
}
