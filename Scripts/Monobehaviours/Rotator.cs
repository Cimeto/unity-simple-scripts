using UnityEngine;

/// <summary>
/// Very simple script to make a transform to rotate
/// </summary>
public class Rotator : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;
    public float SpeedZ;

    private void Update()
    {
        transform.Rotate(SpeedX, SpeedY, SpeedZ);
    }
}