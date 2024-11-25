using UnityEngine;

public class PigManager : MonoBehaviour
{
    public PigTracker pigTracker; // Assign your PigTracker ScriptableObject

    void Start()
    {
        Pig[] allPigs = FindObjectsOfType<Pig>();
        foreach (Pig pig in allPigs)
        {
            if (pigTracker.capturedPigs.Contains(pig.pigID))
            {
                Destroy(pig.gameObject); // Remove the captured pig
            }
        }
    }
}
