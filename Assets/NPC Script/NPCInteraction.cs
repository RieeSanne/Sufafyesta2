using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject speechBubble; // Assign the speech bubble in the Inspector
    private bool isPlayerNear = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            speechBubble.SetActive(true);
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            speechBubble.SetActive(false);
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            DialogueManager.Instance.StartDialogue();
        }
    }
}
