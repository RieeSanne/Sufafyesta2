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
    }

    void Update()
    {
        if (gameOver || SceneManager.GetActiveScene().name == "Overworld") return;

        timer -= Time.deltaTime;
        UpdateTimerUI();

        if (timer <= 0 || pigManager.pigCount >= 4)
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
        SceneManager.LoadScene("Overworld");
    }

    void FindComponentsInScene()
    {
        timerText = GameObject.FindWithTag("TimerText")?.GetComponent<Text>();
        pigManager = FindObjectOfType<PigManager>(); // Locate PigManager in the current scene
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name != "Overworld")
        {
            FindComponentsInScene(); // Update references for the new scene
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
