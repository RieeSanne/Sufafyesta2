using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Mayor : MonoBehaviour
{
    public GameObject ePrompt; // Reference to the E prompt
    public GameObject dialogueBox; // Reference to the Dialogue Box
    public TMPro.TextMeshProUGUI dialogueText; // Reference to the text in the dialogue box

    private bool isPlayerInRange = false;
    private string[] dialogues = new string[] // Array to store dialogues
    {
        "Welcome to the Harvest Festival!",
        "Enjoy the sights, sounds, and festivities.",
        "Don't miss out on the famous pig-chasing contest!",
        "Have fun and make the most of this joyful celebration!"
    };
    private int currentDialogueIndex = 0; // Tracks the current dialogue being displayed

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
            ResetDialogue(); // Reset dialogue when the player leaves
        }
    }

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueBox.activeSelf)
            {
                dialogueBox.SetActive(true); // Show dialogue box
                ShowDialogue(); // Display the first dialogue
            }
            else
            {
                NextDialogue(); // Show the next dialogue or close the box
            }
        }
    }

    private void ShowDialogue()
    {
        dialogueText.text = dialogues[currentDialogueIndex]; // Display the current dialogue
    }

    private void NextDialogue()
    {
        currentDialogueIndex++; // Move to the next dialogue

        if (currentDialogueIndex < dialogues.Length)
        {
            ShowDialogue(); // Show the next dialogue
        }
        else
        {
            ChangeScene(); // Change to the "Overworld" scene
        }
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Overworld"); // Load the "Overworld" scene
    }

    private void ResetDialogue()
    {
        dialogueBox.SetActive(false); // Hide the dialogue box
        currentDialogueIndex = 0; // Reset to the first dialogue
    }
}
