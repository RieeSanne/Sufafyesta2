using UnityEngine;
using UnityEngine.UI;

public class AlternatingButtons : MonoBehaviour
{
    public Button buttonA; // Reference to Button A
    public Button buttonD; // Reference to Button D
    public Sprite buttonAPressed; // Sprite for A button "Pressed"
    public Sprite buttonANotPressed; // Sprite for A button "Not Pressed"
    public Sprite buttonDPressed; // Sprite for D button "Pressed"
    public Sprite buttonDNotPressed; // Sprite for D button "Not Pressed"

    private bool isButtonAPressed = false; // State for Button A

    private Image buttonAImage; // Image component of Button A
    private Image buttonDImage; // Image component of Button D

    void Start()
    {
        // Get Image components for both buttons
        buttonAImage = buttonA.GetComponent<Image>();
        buttonDImage = buttonD.GetComponent<Image>();

        // Initialize button states
        SetButtonAState(false);
        SetButtonDState(false);
    }

    void Update()
    {
        // Check for 'A' key press
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!isButtonAPressed) // Button A can be pressed if it's not already pressed
            {
                SetButtonAState(true);
                SetButtonDState(false); // Automatically set Button D to "Not Pressed"
            }
        }

        // Check for 'D' key press
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (isButtonAPressed) // Button D can only be pressed if Button A is "Pressed"
            {
                SetButtonDState(true);
                SetButtonAState(false); // Automatically set Button A to "Not Pressed"
            }
        }
    }

    void SetButtonAState(bool pressed)
    {
        isButtonAPressed = pressed;
        buttonAImage.sprite = pressed ? buttonAPressed : buttonANotPressed;
    }

    void SetButtonDState(bool pressed)
    {
        buttonDImage.sprite = pressed ? buttonDPressed : buttonDNotPressed;
    }
}
