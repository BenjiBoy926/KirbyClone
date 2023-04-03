using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VectorExtensions
{
    public static Vector2 SetX(this Vector2 vector, float x)
    {
        return vector.SetDimension(x, 0);
    }
    public static Vector2 SetY(this Vector2 vector, float y)
    {
        return vector.SetDimension(y, 1);
    }
    public static Vector2 SetDimension(this Vector2 vector, float value, int dimension)
    {
        if (dimension >= 0 && dimension < 2)
        {
            vector[dimension] = value;
        }
        return vector;
    }
}
