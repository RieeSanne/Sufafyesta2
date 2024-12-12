using UnityEngine;
using UnityEngine.UI;

public class PigManager : MonoBehaviour
{
    
    public int pigCount; // This will track the destroyed pigs
    public Text pigText; // Text UI element to display the pig count
    public PigTracker pigTracker; // Assign your PigTracker ScriptableObject

    private static bool isFirstPlay = true; // Static flag to track the first play

    void OnEnable()
    {
        // Ensure the pigTracker is reset at the start of the game
        if (isFirstPlay)
        {
            isFirstPlay = false; // Ensure this runs only once per play session
            pigTracker.capturedPigs.Clear(); // Reset the captured pigs list
        }
    }

    void Start()
    {
        pigCount = -1; // Initialize the pigCount to zero
        Pig[] allPigs = FindObjectsOfType<Pig>(); // Find all the pig objects in the scene

        foreach (Pig pig in allPigs)
        {
            if (pigTracker.capturedPigs.Contains(pig.pigID)) // Check if the pig is captured
            {
                Destroy(pig.gameObject); // Remove the captured pig
                pigCount++; // Increment the count for each destroyed pig
            }
        }

        UpdateUI(); // Update the UI to reflect the pig count
    }

    void UpdateUI()
    {
        pigText.text = "Pig Count: " + pigCount.ToString(); // Display the pig count
    }
}
