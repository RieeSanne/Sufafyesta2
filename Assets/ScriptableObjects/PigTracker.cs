using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PigTracker", menuName = "ScriptableObjects/PigTracker")]
public class PigTracker : ScriptableObject
{
    public List<int> capturedPigs = new List<int>();

    public void ResetTracker()
    {
        capturedPigs.Clear(); // Clear the list when resetting the tracker
    }
}
