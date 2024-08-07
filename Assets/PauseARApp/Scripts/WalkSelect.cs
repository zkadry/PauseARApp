using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkSelect : MonoBehaviour
{

    public Button breatheButton;
    public Button bubbleButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        breatheButton.onClick.AddListener(OnBreatheButtonClick);
        bubbleButton.onClick.AddListener(OnBubbleButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        
    }

    void OnBubbleButtonClick()
    {
        // Load the Walk mode scene
        // SceneManager.LoadScene("ForestRoute");
        SceneManager.LoadScene("BubbleWalk");
    }

    void OnBreatheButtonClick()
    {
        // Load the Walk mode scene
        // SceneManager.LoadScene("ForestRoute");
        SceneManager.LoadScene("BreathingWalk");
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

}
