using UnityEngine;
using TMPro;

public class InteractionPopUp : MonoBehaviour
{
    public TextMeshProUGUI interactionText; 
    public Transform player;
    public Transform chest;
    public Transform door;
    public float interactionRange = 3f;

    void Start()
    {
        if (interactionText != null)
        {
            interactionText.gameObject.SetActive(false); // Hide text initially
        }
    }

    void Update()
    {
        if (interactionText != null)
        {
            float chestDistance = Vector3.Distance(player.position, chest.position);
            float doorDistance = Vector3.Distance(player.position, door.position);

            if (chestDistance <= interactionRange || doorDistance <= interactionRange)
            {
                interactionText.gameObject.SetActive(true);
            }
            else
            {
                interactionText.gameObject.SetActive(false);
            }
        }
    }
}
