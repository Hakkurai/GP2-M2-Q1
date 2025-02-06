using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                // The player transform
    public Vector3 offset = new Vector3(0, 2, -5); // Camera offset
    public float smoothSpeed = 0.125f;      // Smoothness of movement
    public float rotationSpeed = 3f;        // Speed of rotation

    private float yaw = 0f;  // Horizontal rotation angle
    private float pitch = 0f; // Vertical rotation angle

    void LateUpdate()
    {
        if (target == null) return;

        // Handle camera rotation when RMB is held
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            yaw += mouseX;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -30f, 60f);
        }

        // Apply rotation to the camera
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 rotatedOffset = rotation * offset;

        // Set camera position
        transform.position = Vector3.Lerp(transform.position, target.position + rotatedOffset, smoothSpeed);
        transform.LookAt(target.position);

        // Rotate the player to match the camera direction (only horizontally)
        target.rotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
