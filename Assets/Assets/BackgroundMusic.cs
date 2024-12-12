using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Start playing the music
    }

    public void StopMusic()
    {
        audioSource.Stop(); // Stop the music
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Adjust the volume
    }

    void Awake()
    {
    
     if (FindObjectsOfType<BackgroundMusic>().Length > 1)
    {
        Destroy(gameObject);
        return;
    }

    DontDestroyOnLoad(gameObject);

    }

}
