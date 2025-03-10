using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        // Get the Rigidbody if not already assigned
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // If the player is grounded and falling, reset the vertical velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small negative value to keep the player grounded
        }

        // Movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * x + transform.forward * z;

        // Apply the movement to the Rigidbody, ignoring gravity for now
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);

        // Jumping logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Apply upward force based on jump height
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity manually
        velocity.y += gravity * Time.deltaTime;

        // Apply gravity to the Rigidbody's vertical velocity
        rb.velocity = new Vector3(rb.velocity.x, velocity.y, rb.velocity.z);
    }
}
