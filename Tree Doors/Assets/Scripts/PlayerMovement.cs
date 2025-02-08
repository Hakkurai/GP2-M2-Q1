using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f; // Adjust jump height
    public LayerMask groundLayer; // Layer for the ground
    public Transform groundCheck; // Empty GameObject at the bottom of the capsule
    public Transform cameraTransform; // Reference to the camera
    public AudioSource jumpSound; // Reference to AudioSource

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Get movement direction based on camera rotation
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Prevent movement on the Y-axis
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        // Move in the direction relative to the camera
        Vector3 move = (right * moveX + forward * moveZ).normalized;
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);

        // Rotate the player to face the movement direction
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }

    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            if (jumpSound != null)
            {
                jumpSound.Play(); // Play jump sound
            }
        }
    }
}