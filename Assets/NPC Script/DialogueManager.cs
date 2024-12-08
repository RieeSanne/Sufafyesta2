using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance; // Singleton instance
    public GameObject dialoguePanel; // Assign in Inspector
    public TMPro.TextMeshProUGUI dialogueText; // Assign TMP text field
    public GameObject yesNoButtons; // Assign button group in Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = "Do you want to proceed to the next scene?";
        yesNoButtons.SetActive(true);
    }

    public void OnYesButton()
    {
        SceneManager.LoadScene("NextSceneName"); // Replace with your scene name
    }

    public void OnNoButton()
    {
        dialoguePanel.SetActive(false);
    }
}
