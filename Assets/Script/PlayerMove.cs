using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 5f;

    [Header("Pulo")]
    public float jumpForce = 8f;
    public float gravity = -20f;

    private CharacterController controller;
    private Vector3 velocity;

    [Header("Corrida")]
    public float walkSpeed = 5f;
    public float runSpeed = 10f;

    [Header("Dash")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;

    private bool isDashing;
    private float dashTimer;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        float currentSpeed = walkSpeed;

        // Corrida com Shift
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            currentSpeed = runSpeed;
        }

        // Movimento
        float x = Input.GetAxisRaw("Vertical");
        float z = Input.GetAxisRaw("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;

        // Dash com Q
        if (Keyboard.current.qKey.wasPressedThisFrame && !isDashing)
        {
            isDashing = true;
            dashTimer = dashDuration;
        }

        if (isDashing)
        {
            controller.Move(move.normalized * dashSpeed * Time.deltaTime);

            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0)
            {
                isDashing = false;
            }
        }
        else
        {
            controller.Move(move.normalized * currentSpeed * Time.deltaTime);
        }

        // Pulo
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = 8f;
            Debug.Log("PULOU");
        }

        // Gravidade
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Debug.Log("Grounded: " + controller.isGrounded);

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("ESPAÇO");
        }

    }
}