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
            // Check if this pig has not been captured yet
            if (!pigTracker.capturedPigs.Contains(pigID))
            {
                pigTracker.capturedPigs.Add(pigID); // Add this pig's ID to the PigTracker
                Debug.Log("Captured Pig ID: " + pigID); // Debug log to confirm capture
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

    // Ensure the PigTracker persists between scenes
    void Awake()
    {
        // Ensure the PigTracker persists across scenes
        DontDestroyOnLoad(pigTracker);
    }
}
