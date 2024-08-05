using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnywhereSelect : MonoBehaviour
{
    public Button startButton;
    public Button backButton;
    public Slider timerSlider;
    private int selectedTime = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        startButton.onClick.AddListener(OnStartButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);

        // initialise slider defaults
        timerSlider.minValue = 10;
        timerSlider.maxValue = 30;
        timerSlider.value = selectedTime;
        
    }

    void OnStartButtonClick()
    {
        selectedTime = (int)timerSlider.value; // get selected duration
        PlayerPrefs.SetInt("SelectedTime", selectedTime); // store selected time
        SceneManager.LoadScene("WalkAnywhere"); // load the Walk mode scene
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

}
