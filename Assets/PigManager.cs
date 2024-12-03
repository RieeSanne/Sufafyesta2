using UnityEngine;
using UnityEngine.UI;

public class PigManager : MonoBehaviour
{
    public int pigCount; // This will track the destroyed pigs
    public Text pigText; // Text UI element to display the pig count
    public PigTracker pigTracker; // Assign your PigTracker ScriptableObject

    private static bool isFirstPlay = true; // Static flag to track the first play

    void Start()
    {
        if (isFirstPlay)
        {
            isFirstPlay = false; // Ensure this runs only once per play session
            pigTracker.capturedPigs.Clear(); // Reset the captured pigs list
        }

        pigCount = 0; // Initialize the pigCount to zero
        Pig[] allPigs = FindObjectsOfType<Pig>();

        foreach (Pig pig in allPigs)
        {
            if (pigTracker.capturedPigs.Contains(pig.pigID))
            {
                Destroy(pig.gameObject); // Remove the captured pig
                pigCount++; // Increment the count for each destroyed pig
            }
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        pigText.text = "Pig Count: " + pigCount.ToString(); // Display the pig count
    }
}
