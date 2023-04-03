using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RigidbodyExtensions
{
    public static void SetVelocityX(this Rigidbody2D rb, float x)
    {
        rb.SetVelocityDimension(x, 0);
    }
    public static void SetVelocityY(this Rigidbody2D rb, float y)
    {
        rb.SetVelocityDimension(y, 1);
    }
    public static void SetVelocityDimension(this Rigidbody2D rb, float value, int dimension)
    {
        rb.velocity = rb.velocity.SetDimension(value, dimension);
    }
}
