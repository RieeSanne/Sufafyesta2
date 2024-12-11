using UnityEngine;
using TMPro; // Required for TextMeshPro (if you are using TextMeshPro)
using UnityEngine.SceneManagement;

public class QTEManager : MonoBehaviour
{
    public int requiredPresses; // Total number of alternating presses required
    private int remainingPresses; // Tracks the remaining presses
    private bool lastPressedA = false; // Tracks the last button pressed

    public TextMeshProUGUI pressCountText; // Reference to the TextMeshProUGUI component

    void Start()
    {
        // Randomize the required number of presses between 20 and 40
        requiredPresses = Random.Range(20, 41);
        remainingPresses = requiredPresses; // Set remaining presses to the same as the required presses
        Debug.Log("QTE Required Presses: " + requiredPresses); // Optional: print to see the random value

        // Initialize the text to display the remaining presses
        UpdatePressCountText();
    }

    void Update()
    {
        // Check if the player presses "A"
        if (Input.GetKeyDown(KeyCode.A) && !lastPressedA)
        {
            remainingPresses--; // Decrease the remaining presses
            lastPressedA = true; // Set lastPressedA to true, indicating "A" was the last key pressed
            CheckQTECompletion();
        }
        // Check if the player presses "D"
        else if (Input.GetKeyDown(KeyCode.D) && lastPressedA)
        {
            remainingPresses--; // Decrease the remaining presses
            lastPressedA = false; // Set lastPressedA to false, indicating "D" was the last key pressed
            CheckQTECompletion();
        }

        // Update the remaining presses on screen
        UpdatePressCountText();
    }

    // Method to check if QTE is completed
    private void CheckQTECompletion()
    {
        if (remainingPresses <= 0)
        {
            // Load the original scene once the QTE is completed
            SceneManager.LoadScene("Habulan"); // Replace "Habulan" with your scene name
        }
    }

    // Method to update the text display
    private void UpdatePressCountText()
    {
        // Just display the remaining presses as a number
        pressCountText.text = remainingPresses.ToString();
    }
}
