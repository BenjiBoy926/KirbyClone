using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kirby Configuration")]
public class KirbyConfiguration : ScriptableObject
{
    [SerializeField]
    private RigidbodyMovement2D _walkingMovement = new RigidbodyMovement2D(20, 5);
    [SerializeField]
    private float _jumpSpeed = 10;
    [SerializeField]
    private float _jumpTime = 0.5f;
    [SerializeField]
    private RigidbodyMovement2D _airMovement = new RigidbodyMovement2D(10, 10);
    [SerializeField]
    private float _floatSpeed = 7;
    [SerializeField]
    private float _floatingGravity = 1.5f;
    [SerializeField]
    private RigidbodyMovement2D _floatingMovement = new RigidbodyMovement2D(5, 5);

    public RigidbodyMovement2D WalkingMovement => _walkingMovement;
    public float JumpSpeed => _jumpSpeed;
    public float JumpTime => _jumpTime;
    public RigidbodyMovement2D AirMovement => _airMovement;
    public float FloatSpeed => _floatSpeed;
    public float FloatingGravity => _floatingGravity;
    public RigidbodyMovement2D FloatingMovement => _floatingMovement;
}
