using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DrawVector2D
{
    public static void Draw(this Vector2 vector, Color color)
    {
        Debug.DrawLine(Vector3.zero, vector, color);
    }

    public static void Draw(this Vector2 vector, Vector2 origin, Color color)
    {
        Debug.DrawLine(origin, origin + vector, color);
    }
}
