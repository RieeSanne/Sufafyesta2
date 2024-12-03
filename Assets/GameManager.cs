using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PigTracker pigTracker; // Assign the PigTracker instance in the Inspector

    private static GameManager instance;

    void Awake()
    {
        // Singleton pattern to ensure a single GameManager instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

        InitializePigTracker();
    }

    private void InitializePigTracker()
    {
        if (pigTracker == null)
        {
            Debug.LogError("PigTracker is not assigned in GameManager!");
        }
        else
        {
            Debug.Log("PigTracker initialized.");
            pigTracker.capturedPigs.Clear(); // Ensure the list is clear at game start
        }
    }
}
