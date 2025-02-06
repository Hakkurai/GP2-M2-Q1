using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    // This will detect the collision with the "Game Over" box collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player (you can add more specific checks like tag if needed)
        if (other.CompareTag("Player"))
        {
            // Output "Game Over" to the console
            Debug.Log("Game Over! Returning to Main Level. . .");

            // Load the main level (replace "MainLevel" with the actual scene name)
            SceneManager.LoadScene("MainLevel"); // Make sure "MainLevel" matches your scene name in the build settings
        }
    }
}
