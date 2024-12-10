using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject ePrompt; // Reference to the E prompt
    public GameObject dialogueBox; // Reference to the Dialogue Box
    public TMPro.TextMeshProUGUI dialogueText; // Reference to the text in the dialogue box (or UnityEngine.UI.Text)

    private bool isPlayerInRange = false;

    private void Start()
    {
        ePrompt.SetActive(false); // Hide E prompt initially
        dialogueBox.SetActive(false); // Hide dialogue box initially
    }

    private void OnTriggerEnter(Collider other) // For 3D
    {
        if (other.CompareTag("Player"))
        {
            ePrompt.SetActive(true); // Show E prompt
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other) // For 3D
    {
        if (other.CompareTag("Player"))
        {
            ePrompt.SetActive(false); // Hide E prompt
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueBox.activeSelf)
            {
                dialogueBox.SetActive(true); // Show dialogue box
                dialogueText.text = "Hi Player! Are you interested in joining the habulan ng baboy game?"; // Example dialogue
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                dialogueBox.SetActive(false); // Hide dialogue box
            }
        }
    }
}
