using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public CharacterController controller; // A variable to hold the player's chatacyer controller component

    public float moveSpeed = 5; // A variable to control how fast the player moves

    private Vector3 moveDirections = Vector3.zero; // A vector (x,y,z) to determine the direction the player moves in

    public float jumpForce = 5f; // Jump force

    public int health;

    public LayerMask groundLayer; // Layer to check if the player is grounded
    private bool isGrounded; // Whether the player is or isn't grounded
    public float groundCheckDist = 1.0f; // Check if grounded by distance

    public float gravity = -9.81f; // Gravity constant value
    public float gravityScale = 3f; // Adjust the gravity scale as needed
    private Vector3 velocity; // Player's current velocity

    private EnemyFollow enemy;
    void Start()
    {
        controller = GetComponent<CharacterController>();

        enemy = FindObjectOfType<EnemyFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        // Gather input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput); // Calculate direction the player should move based on our collected input

        movement = transform.TransformDirection(movement); // Convert the direction into local space; this means 'forward' will be relative to the direction the playeris facing rather than the global 'forward'
        
        controller.Move(movement *moveSpeed* Time.deltaTime); // Move the player based on the input

        ApplyGravity(); // Apply gravity to the player

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        // Set the velocity for the jump
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity * gravityScale);
    }

    void ApplyGravity()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded || IsGrounded();

        // If grounded and descending, set a small negative value to keep the player grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Apply gravity to the velocity
        velocity.y += gravity * gravityScale * Time.deltaTime;

        // Move the player using the CharacterController
        controller.Move(velocity * Time.deltaTime);
    }

    bool IsGrounded()
    {
        // Perform a Raycast dowward to check if there's ground beneath the player
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDist, groundLayer);
    }
}
