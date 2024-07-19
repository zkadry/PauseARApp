using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ActivitySelect : MonoBehaviour
{
    public Button breatheButton;
    public Button bubbleButton;
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // assign button click listeners
        breatheButton.onClick.AddListener(OnBreatheButtonClick);
        bubbleButton.onClick.AddListener(OnBubbleButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    void OnBreatheButtonClick()
    {
        SceneManager.LoadScene("BreatheSelect");
    }

    void OnBubbleButtonClick()
    {
        SceneManager.LoadScene("BubbleSelect");
    }

    void OnBackButtonClick()
    {
        // load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }
}
