using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public GameObject[] doors;  // Assign the 3 doors in the Inspector
    private bool isPlayerNearby = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the chest. Press 'E' to interact.");
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
            Debug.Log("Player interacted with the chest.");
            OpenDoors();
        }
    }

    void OpenDoors()
    {
        foreach (GameObject door in doors)
        {
            if (door != null)
            {
                Debug.Log(" The Doors are now open!");
            }
        }
    }
}
