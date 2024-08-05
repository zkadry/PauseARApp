using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class AnywhereSelect : MonoBehaviour
{
    public Button startButton;
    public Button backButton;
    public Button limitlessButton;
    public Slider timerSlider;
    private int selectedTime = 10;
    public TMP_Text selectedTimeText;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        startButton.onClick.AddListener(OnStartButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        limitlessButton.onClick.AddListener(OnLimitlessButtonClick);

        // initialise slider defaults
        timerSlider.minValue = 1;
        timerSlider.maxValue = 30;
        timerSlider.value = 10;
        timerSlider.wholeNumbers = true; // increment in whole numbers (minutes)

        // update displayed time
        UpdateSelectedTimeText(timerSlider.value);

        // listener for slider to update selected time text
        timerSlider.onValueChanged.AddListener(delegate { UpdateSelectedTimeText(timerSlider.value); });
        
    }

    void OnStartButtonClick()
    {
        int selectedTime = (int)timerSlider.value; // get selected duration
        PlayerPrefs.SetInt("SelectedTime", selectedTime); // store selected time
        SceneManager.LoadScene("WalkAnywhere"); // load the Walk mode scene
    }

    void OnLimitlessButtonClick()
    {
        PlayerPrefs.SetInt("SelectedTime", -1); // store -1 to indicate limitless mode
        SceneManager.LoadScene("WalkAnywhere");
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

    void UpdateSelectedTimeText(float value)
    {
        selectedTimeText.text = value.ToString("0") + " minutes.";
    }

}
