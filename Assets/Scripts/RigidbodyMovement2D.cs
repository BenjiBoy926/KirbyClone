using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RigidbodyMovement2D
{
    public const float Tolerance = 0.001f;

    [SerializeField]
    private float _acceleration;
    [SerializeField]
    private float _topSpeed;

    public RigidbodyMovement2D(float acceleration, float topSpeed)
    {
        _acceleration = acceleration;
        _topSpeed = topSpeed;
    }

    public void Move(Rigidbody2D rigidbody, int normalizedTargetSpeed, int axis)
    {
        float normalizedCurrentSpeed = rigidbody.velocity[axis] / _topSpeed;
        float difference = normalizedTargetSpeed - normalizedCurrentSpeed;

        if (Mathf.Abs(difference) > Tolerance)
        {
            Vector2 force = Vector2.zero;
            force[axis] = _acceleration * Mathf.Sign(difference);
            rigidbody.AddForce(force);
        }
    }
}
