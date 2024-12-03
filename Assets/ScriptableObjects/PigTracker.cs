using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PigTracker", menuName = "ScriptableObjects/PigTracker")]
public class PigTracker : ScriptableObject
{
    public List<int> capturedPigs = new List<int>();
private void OnEnable()
    {
        DontDestroyOnLoad(this);  // Ensures the PigTracker is not destroyed when loading a new scene
    }
    public void start()
    {
        capturedPigs.Clear(); // Clear the list when resetting the tracker
    }
}
