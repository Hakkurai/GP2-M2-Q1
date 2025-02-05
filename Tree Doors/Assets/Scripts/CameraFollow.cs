using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;               // The player (capsule) transform
    public Vector3 offset = new Vector3(0, 2, -5); // Offset position from the target
    public float smoothSpeed = 0.125f;     // Smoothness of the camera movement

    void LateUpdate()
    {
        if (target == null) return;

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);

        // Smoothly interpolate to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Rotate the camera to always look at the target
        transform.LookAt(target);
    }
}

