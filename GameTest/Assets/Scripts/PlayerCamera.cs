using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the character's transform.
    public Vector3 offset;   // Offset from the character's position.

    void LateUpdate()
    {
        if (target != null)
        {
            // Calculate the desired position of the camera.
            Vector3 desiredPosition = target.position + offset;

            // Set the camera's position to the desired position.
            transform.position = desiredPosition;

            // Make sure the camera looks at the character.
            transform.LookAt(target.position);
        }
    }
}