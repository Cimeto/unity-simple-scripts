using UnityEngine;

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