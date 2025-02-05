using UnityEngine;
using UnityEngine.SceneManagement;  // Load Scene

public class DoorInteraction2 : MonoBehaviour
{
    private bool isPlayerNearby = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the door. Press 'E' to enter Level 2.");
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
            Debug.Log("Player is entering Level 2...");
            SceneManager.LoadScene("Level 2"); // Load Level 2
        }
    }
}
