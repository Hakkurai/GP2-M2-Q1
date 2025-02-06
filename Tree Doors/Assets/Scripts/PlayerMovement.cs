using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f; // Adjust jump height
    public LayerMask groundLayer; // Layer for the ground
    public Transform groundCheck; // Empty GameObject at the bottom of the capsule

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

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.linearVelocity = new Vector3(move.x * moveSpeed, rb.linearVelocity.y, move.z * moveSpeed);
    }

    void Jump()
    {
        // Check if player is on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
        }
    }
}
