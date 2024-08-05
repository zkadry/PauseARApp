using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WalkAnywhereTimer : MonoBehaviour
{
    public TMP_Text timerText;
    public GameObject endPopup;
    public Button exitButton;
    public Button menuButton;

    private bool isLimitless = false;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        int selectedTime = PlayerPrefs.GetInt("SelectedTime", 10); // get selected time from PlayerPrefs. default to 10 if not found

        if (selectedTime == -1) // check for limitless mode
        {
            isLimitless = true;
            startTime = Time.time; // set time to current time
        }
        else
        {
            startTime = Time.time + selectedTime * 60f; // convert minutes to secs
            UpdateTimer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isLimitless)
        {
            UpdateLimitlessTimer();
        }
        else{
            UpdateTimer();
            
            if (Time.time > startTime)
            {
                EndTimer(); // call method to handlle end of timer
            }
        }
    }

    void UpdateTimer()
    {
        float currentTime = Mathf.FloorToInt(startTime - Time.time);
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    void UpdateLimitlessTimer()
    {
        float currentTime = Mathf.FloorToInt(Time.time - startTime);
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);
    }

    void EndTimer()
    {
        endPopup.SetActive(true);
        exitButton.onClick.AddListener(() => { Application.Quit(); });
        menuButton.onClick.AddListener(() => { SceneManager.LoadScene("ChooseYourExperience"); });
    }
}
