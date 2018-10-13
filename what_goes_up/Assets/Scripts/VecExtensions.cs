using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class VecExtensions
{
    public static Vector2 Rotate(this Vector2 vec, float angle)
    {
        var sin = Mathf.Sin(angle);
        var cos = Mathf.Cos(angle);

        var x = (cos * vec.x) - (sin * vec.y);
        var y = (sin * vec.x) + (cos * vec.y);

        return new Vector2(x, y);
    }
}
