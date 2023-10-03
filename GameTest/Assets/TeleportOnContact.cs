using UnityEngine;

public class TeleportOnContact : MonoBehaviour
{
    public Transform teleportDestination; // The position to teleport the player to

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Get the CharacterController component from the player GameObject
            CharacterController characterController = other.GetComponent<CharacterController>();

            // Check if CharacterController is not null
            if (characterController != null)
            {
                // Teleport the player to the specified destination
                characterController.enabled = false; // Disable the CharacterController temporarily to set position
                other.transform.position = teleportDestination.position;
                characterController.enabled = true; // Re-enable the CharacterController
            }
        }
    }
}