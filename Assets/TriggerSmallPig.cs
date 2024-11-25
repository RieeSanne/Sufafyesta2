using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSmallPig : MonoBehaviour
{
    public PigTracker pigTracker; // Reference to the PigTracker ScriptableObject
    public int pigID; // Unique ID for each pig

    // Method called when the player collides with this pig
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Add this pig's ID to the PigTracker
            if (!pigTracker.capturedPigs.Contains(pigID))
            {
                pigTracker.capturedPigs.Add(pigID);
            }

            // Load the QTE scene or SmallPig scene
            LoadScene("SmallPig");
        }
    }

    // Method to load a scene
    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
