using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    // Vector3

    static public Vector3 X(this Vector3 v, float x)
    {
        v.x = x;
        return v;
    }

    static public Vector3 Y(this Vector3 v, float y)
    {
        v.y = y;
        return v;
    }

    static public Vector3 Z(this Vector3 v, float z)
    {
        v.z = z;
        return v;
    }
}
