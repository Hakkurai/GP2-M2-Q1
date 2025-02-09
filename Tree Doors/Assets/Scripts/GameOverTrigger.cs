using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    // This will detect the collision with the "Game Over" box collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player 
        if (other.CompareTag("Player"))
        {

            // Load the GameOverScene 
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
