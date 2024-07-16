using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BreatheSelect : MonoBehaviour
{
    public Button startButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        startButton.onClick.AddListener(OnStartButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
        
    }

    void OnStartButtonClick()
    {
        // Load the Walk mode scene
        SceneManager.LoadScene("BreatheActivity");
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

}
