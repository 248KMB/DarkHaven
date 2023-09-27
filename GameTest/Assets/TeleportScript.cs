using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{
    public string destinationSceneName; // The name of the destination scene
    public Transform teleportDestination; // The position to teleport the player to

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Load the destination scene
            SceneManager.LoadScene(destinationSceneName);

            // Teleport the player to the specified position in the destination scene
            other.transform.position = teleportDestination.position;
        }
    }
}