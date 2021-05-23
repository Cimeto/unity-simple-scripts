using UnityEngine;

/// <summary>
/// This script applies a tank-style movement to an object to be controlled by a player making use of a keyboard
/// Originally designed for top-down 2D games
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerKeyboardTankMovement2D : MonoBehaviour
{
    [Header("Player input")]
    public string LeftKeyCode;
    public string RightKeyCode;
    public string UpKeyCode;
    public string DownKeyCode;

    [Header("Object speed")]
    public float ForwardSpeed = 1f;
    public float BackwardSpeed = 0.5f;
    public float TurnSpeed = 1f;

    private float movementInputValue;
    private float turnInputValue;
    private float turnAngle;
    private Vector2 forwardVector;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        forwardVector = Vector2.up;
    }

    private void Update()
    {
        movementInputValue = 0;
        if (Input.GetKey(UpKeyCode)) { movementInputValue = 1; }
        if (Input.GetKey(DownKeyCode)) { movementInputValue = -1; }

        turnInputValue = 0;
        if (Input.GetKey(LeftKeyCode)) { turnInputValue = -1; }
        if (Input.GetKey(RightKeyCode)) { turnInputValue = 1; }
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        rb2d.velocity = forwardVector * movementInputValue
            * (movementInputValue > 0 ? ForwardSpeed : BackwardSpeed);
    }

    private void Turn()
    {
        turnAngle += (turnInputValue * TurnSpeed);
        rb2d.MoveRotation(-turnAngle);

        forwardVector = forwardVector.Rotate(-(turnInputValue * TurnSpeed));
    }
}