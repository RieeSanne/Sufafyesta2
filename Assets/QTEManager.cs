using UnityEngine;
using UnityEngine.SceneManagement;

public class QTEManager : MonoBehaviour
{
    public int requiredPresses = 30; // Total number of alternating presses required
    private int pressCount = 0;
    private bool lastPressedA = false; // Tracks the last button pressed

    void Update()
    {
        // Check if the player presses "A"
        if (Input.GetKeyDown(KeyCode.A) && !lastPressedA)
        {
            pressCount++;
            lastPressedA = true; // Set lastPressedA to true, indicating "A" was the last key pressed
            CheckQTECompletion();
        }
        // Check if the player presses "D"
        else if (Input.GetKeyDown(KeyCode.D) && lastPressedA)
        {
            pressCount++;
            lastPressedA = false; // Set lastPressedA to false, indicating "D" was the last key pressed
            CheckQTECompletion();
        }
    }

    // Method to check if QTE is completed
    private void CheckQTECompletion()
    {
        if (pressCount >= requiredPresses)
        {
            // Load the original scene once the QTE is completed
            SceneManager.LoadScene("Habulan"); // Replace "SmallPig" with the name of your original scene
        }
    }
}
