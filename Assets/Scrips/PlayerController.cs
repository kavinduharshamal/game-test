using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRb;

    private PlayerInputSet input;

    public float moveSpeed = 8;
    public float jumpForce = 20;

    void Awake()
    {
        input = new PlayerInputSet();
    }

    void OnEnable()
    {
        input.Enable();
    }

    void Update()
    {
        Vector2 moveInput = input.Player.Movement.ReadValue<Vector2>();

        theRb.linearVelocity = new Vector2(
            moveInput.x * moveSpeed,
            theRb.linearVelocity.y
        );

        if(input.Player.Jump.WasCompletedThisFrame())
        theRb.linearVelocity = new Vector2(
            theRb.linearVelocityX,
            jumpForce
        );
    }

    void OnDisable()
    {
        input.Disable();
    }
}