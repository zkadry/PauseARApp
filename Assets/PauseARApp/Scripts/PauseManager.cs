using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    // References to UI elements
    public GameObject pausePopupPanel; // The panel that contains the pause menu
    public Button pauseButton; // The button that shows the pause menu
    public Button continueButton; // The button to resume the game
    public Button mainMenuButton; // The button to exit to the main menu

    // Tracks whether the game is currently paused
    private bool isPaused = false;

    void Start()
    {
        // Initially hide the pause menu
        pausePopupPanel.SetActive(false);

        // Attach event listeners to the pause menu buttons
        pauseButton.onClick.AddListener(ShowPausePopup);
        continueButton.onClick.AddListener(Resume);
        mainMenuButton.onClick.AddListener(MainMenu);
    }

    void Update()
    {
        // Check for the escape key press to toggle pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume(); // Resume the game if it's paused
            }
            else
            {
                Pause(); // Pause the game if it's not already paused
            }
        }
    }

    // Shows the pause menu
    void ShowPausePopup()
    {
        pausePopupPanel.SetActive(true); // Activate the pause menu panel
    }

    // Pauses the game
    void Pause()
    {
        Time.timeScale = 0f; // Freeze time, pausing all game actions
        isPaused = true; // Mark the game as paused
        pausePopupPanel.SetActive(true); // Display the pause menu
        // Optionally, pause any custom activities here
    }

    // Resumes the game
    void Resume()
    {
        Time.timeScale = 1f; // Unfreeze time, allowing game actions to proceed normally
        isPaused = false; // Mark the game as unpaused
        pausePopupPanel.SetActive(false); // Hide the pause menu
        // Optionally, resume any custom activities here
    }

    // Exits to the main menu
    void MainMenu()
    {
        Time.timeScale = 1f; // Ensure time is unfrozen before changing scenes
        SceneManager.LoadScene("ChooseYourExperience"); // Replace "ChooseYourExperience" with your actual main menu scene name
    }

    // Getter method to check if the game is paused
    public bool IsPaused()
    {
        return isPaused;
    }
}

