using UnityEngine;
using UnityEngine.SceneManagement;  // Load Scene

public class DoorInteraction4 : MonoBehaviour
{
    private bool isPlayerNearby = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the door. Press 'E' to enter Main Level");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("YOU WIN!");
            SceneManager.LoadScene("MainLevel"); // Load Main Level
        }
    }
}
