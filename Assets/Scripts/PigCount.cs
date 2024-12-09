using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PigCount : MonoBehaviour
{
    public int pigCount;
    public Text pigText;
  
    void Start()
    {
        
    }


    void Update()
    {
        pigText.text = "Pig Count: " + pigCount.ToString();
    }
}
