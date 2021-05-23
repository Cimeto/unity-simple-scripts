using UnityEngine;

public static class Vector2Extension
{
    /// <summary>
    /// Rotate vector in euler degrees
    /// </summary>
    /// <param name="v"></param>
    /// <param name="degrees"></param>
    /// <returns></returns>
    public static Vector2 Rotate(this Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);

        return v;
    }

    /// <summary>
    /// Returns a shooting intercept vector
    /// </summary>
    /// <param name="shooterPosition"></param>
    /// <param name="shooterVelocity"></param>
    /// <param name="shotSpeed"></param>
    /// <param name="targetPosition"></param>
    /// <param name="targetVelocity"></param>
    /// <returns></returns>
    public static Vector2 FirstOrderIntercept(Vector2 shooterPosition, Vector2 shooterVelocity,
        float shotSpeed, Vector2 targetPosition, Vector2 targetVelocity)
    {
        Vector2 targetRelativePosition = targetPosition - shooterPosition;
        Vector2 targetRelativeVelocity = targetVelocity - shooterVelocity;

        float t = FirstOrderInterceptTime(shotSpeed, targetRelativePosition, targetRelativeVelocity);

        return targetPosition + t * (targetRelativeVelocity);
    }

    // first-order intercept using relative target position
    private static float FirstOrderInterceptTime(float shotSpeed, Vector2 targetRelativePosition,
        Vector2 targetRelativeVelocity)
    {
        float velocitySquared = targetRelativeVelocity.sqrMagnitude;
        if (velocitySquared < 0.001f)
            return 0f;

        float a = velocitySquared - shotSpeed * shotSpeed;

        // handle similar velocities
        if (Mathf.Abs(a) < 0.001f)
        {
            float t = -targetRelativePosition.sqrMagnitude /
                (2f * Vector2.Dot(targetRelativeVelocity, targetRelativePosition));
            return Mathf.Max(t, 0f); //don't shoot back in time
        }

        float b = 2f * Vector2.Dot(targetRelativeVelocity, targetRelativePosition);
        float c = targetRelativePosition.sqrMagnitude;
        float determinant = b * b - 4f * a * c;

        if (determinant > 0f) //determinant > 0; two intercept paths (most common)
        {
            float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
                    t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
            if (t1 > 0f)
            {
                if (t2 > 0f)
                    return Mathf.Min(t1, t2); //both are positive
                else
                    return t1; //only t1 is positive
            }
            else
                return Mathf.Max(t2, 0f); //don't shoot back in time
        }
        else if (determinant < 0f) //determinant < 0; no intercept path
            return 0f;
        else //determinant = 0; one intercept path, pretty much never happens
            return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
    }

    /// <summary>
    /// Returns average from vector values
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static float Average(this Vector2 v)
    {
        return (v.x + v.y) / 2;
    }
}