using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;
    public Button exitButton;
    public BubbleSpawner bubbleSpawner;
    public BreathingActivityManager breathingActivityManager;

    // Start is called before the first frame update
    void Start()
    {
        // assign the button click listeners
        exitButton.onClick.AddListener(OnExitButtonClick);
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void OnExitButtonClick()
    {
        Time.timeScale = 1;

        if (bubbleSpawner != null)
        {
            bubbleSpawner.ResetActivity();
        }

        if (breathingActivityManager != null)
        {
            breathingActivityManager.ResetActivity();
        }

        // load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }
}
