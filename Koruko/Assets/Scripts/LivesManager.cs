using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PlayerMovement;

public class LivesManager : MonoBehaviour
{
    public Text livesText; // UI Text element to display lives
    public PlayerMovement player; // Reference to the PlayerMovement script

    void Update()
    {
        // Display lives counter in UI
        livesText.text = GameState.Lives.ToString();
    }
}
