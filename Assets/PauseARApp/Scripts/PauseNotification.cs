using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseNotification : MonoBehaviour
{
    public TMP_InputField minutesInputField;
    public Button scheduleButton;
    public Button pauseButton;
    public Button playButton;
    public Button backButton;
    public TMP_Text countdownText;
    private NotificationManager notificationManager;
    private float timeRemaining;
    private bool isTimerRunning = false;
    private bool isPaused = false;

    void Start()
    {
        notificationManager = FindObjectOfType<NotificationManager>();

        backButton.onClick.AddListener(OnBackButtonClick);

        if (scheduleButton != null)
        {
            scheduleButton.onClick.AddListener(OnScheduleButtonClick);
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
        }

        UpdateButtonVisibility();
    }

    void Update()
    {
        if (isTimerRunning && !isPaused)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining < 0) // ensure time doesn't go below 0
                {
                    timeRemaining = 0;
                    isTimerRunning = false;
                    UpdateButtonVisibility();
                }
                UpdateCountdownText(timeRemaining);
            }
            else
            {
                Debug.Log("Timer has finished.");
                isTimerRunning = false;
                UpdateButtonVisibility(); // update button visibility when timer finishes
            }
        }
    }

    void OnScheduleButtonClick()
    {
        if (int.TryParse(minutesInputField.text, out int minutes) && minutes > 0)
        {
            notificationManager.ScheduleNotification(minutes);
            Debug.Log("Notification scheduled for " + minutes + " minutes.");
            timeRemaining = minutes * 60;
            isTimerRunning = true;
            isPaused = false; // ensure timer is not paused when started
            UpdateButtonVisibility(); // update button visibility when timer starts
        }
        else
        {
            Debug.Log("Invalid input. Please enter a positive number.");
        }
    }

    void OnPauseButtonClick()
    {
        if (isTimerRunning)
        {
            isPaused = true;
            UpdateButtonVisibility();
            Debug.Log("Timer paused.");
        }
    }

    void OnPlayButtonClick()
    {
        if (isTimerRunning && isPaused)
        {
            isPaused = false;
            UpdateButtonVisibility();
            Debug.Log("Timer resumed.");
        }
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

    void UpdateButtonVisibility()
    {
        if (pauseButton != null)
        {
            pauseButton.gameObject.SetActive(isTimerRunning && !isPaused);
        }

        if (playButton != null)
        {
            playButton.gameObject.SetActive(isTimerRunning && isPaused);
        }
    }

    void UpdateCountdownText(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        countdownText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }
}
