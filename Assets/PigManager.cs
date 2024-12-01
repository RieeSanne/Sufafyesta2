using UnityEngine;
using UnityEngine.UI;

public class PigManager : MonoBehaviour
{
    public int pigCount; // This will track the destroyed pigs
    public Text pigText; // Text UI element to display the pig count
    public PigTracker pigTracker; // Assign your PigTracker ScriptableObject

    void Start()
    {
        Pig[] allPigs = FindObjectsOfType<Pig>();
        pigCount = 0; // Initialize the pigCount to zero

        foreach (Pig pig in allPigs)
        {
            if (pigTracker.capturedPigs.Contains(pig.pigID))
            {
                Destroy(pig.gameObject); // Remove the captured pig
                pigCount++; // Increment the count for each destroyed pig
            }
        }
    }

    void Update()
    {
        pigText.text = "Pig Count: " + pigCount.ToString(); // Display the pig count
    }
}
