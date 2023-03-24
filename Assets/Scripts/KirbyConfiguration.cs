using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Kirby Configuration")]
public class KirbyConfiguration : ScriptableObject
{
    [SerializeField]
    private RigidbodyMovement2D _walkingMovement = new RigidbodyMovement2D(20, 5);
    [SerializeField]
    private RigidbodyMovement2D _airMovement = new RigidbodyMovement2D(10, 10);
    [SerializeField]
    private float _jumpSpeed = 10;
    [SerializeField]
    private float _jumpTime = 0.5f;

    public RigidbodyMovement2D WalkingMovement => _walkingMovement;
    public RigidbodyMovement2D AirMovement => _airMovement;
    public float JumpSpeed => _jumpSpeed;
    public float JumpTime => _jumpTime;
}
