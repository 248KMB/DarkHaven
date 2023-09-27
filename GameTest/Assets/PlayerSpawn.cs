using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public string spawnPointTag = "SpawnPoint"; // Tag of the spawn point GameObject

    private void Start()
    {
        // Find the spawn point in the current scene using its tag
        GameObject spawnPoint = GameObject.FindGameObjectWithTag(spawnPointTag);

        // Teleport the player to the spawn point's position
        if (spawnPoint != null)
        {
            // Assuming "Player" is the tag of your player character
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = spawnPoint.transform.position;
        }
        else
        {
            Debug.LogError("Spawn point not found in the scene!");
        }
    }
}