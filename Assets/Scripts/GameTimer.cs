using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float timer = 60f; // Set the timer in seconds
    public Text timerText; // UI element for the timer display
    public PigManager pigManager; // Reference to your PigManager script

    private bool gameOver = false; // Flag to prevent multiple scene loads
    public static GameTimer Instance; // Singleton instance

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Preserve across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate timers
        }
    }

    void Start()
    {
        FindComponentsInScene(); // Find timerText and PigManager in the current scene

        // Reset the timer when transitioning to gameplay scenes
        if (SceneManager.GetActiveScene().name == "GameScene") // Replace "GameScene" with your actual gameplay scene name
        {
            timer = 60f; // Reset timer to initial value
            gameOver = false; // Reset gameOver flag
        }
    }

    void Update()
    {
        if (gameOver || SceneManager.GetActiveScene().name == "Win" || SceneManager.GetActiveScene().name == "Lose")
            return;

        timer -= Time.deltaTime; // Decrease the timer over time
        UpdateTimerUI(); // Update the UI display

        // Check for timer expiration
        if (timer <= 0)
        {
            LoadLose();
        }
        else if (pigManager != null && pigManager.pigCount >= 4)
        {
            LoadOverworld();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Max(timer, 0).ToString("F2"); // Update the timer UI
        }
    }

    void LoadOverworld()
    {
        gameOver = true;
        if (SceneTransition.Instance != null)
        {
            SceneTransition.Instance.FadeOutAndLoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }

    void LoadLose()
    {
        gameOver = true;
        if (SceneTransition.Instance != null)
        {
            SceneTransition.Instance.FadeOutAndLoadScene("Lose");
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }

   void FindComponentsInScene()
{
    timerText = GameObject.FindWithTag("TimerText")?.GetComponent<Text>();
    pigManager = FindObjectOfType<PigManager>(); // Locate PigManager in the current scene

    // Debugging
    if (timerText != null)
    {
        Debug.Log("TimerText found and assigned!");
    }
    else
    {
        Debug.LogError("TimerText reference is missing in the scene!");
    }
}


    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Win" && scene.name != "Lose")
        {
            FindComponentsInScene(); // Update references for the new scene

            // Reset timer when entering the relevant scene
            if (scene.name == "GameScene") // Replace with your actual game scene name
            {
                timer = 60f; // Reset timer
                gameOver = false; // Reset gameOver flag
            }
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene changes
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe when disabled
    }
}
