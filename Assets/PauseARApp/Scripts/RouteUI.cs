using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RouteUI : MonoBehaviour
{
    public GameObject exitPopupPanel;
    public Button exitButton;
    public Button yesButton;
    public Button noButton;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure pop-up panel is not initially active
        exitPopupPanel.SetActive(false);

        // Assign the button click listeners
        exitButton.onClick.AddListener(ShowExitPopup);
        noButton.onClick.AddListener(HideExitPopup);
        yesButton.onClick.AddListener(OnYesButtonClick);
        
    }

    void ShowExitPopup()
    {
        // Show exit pop-up
        exitPopupPanel.SetActive(true);
    }

    void HideExitPopup() 
    {
        // Hide exit pop-up
        exitPopupPanel.SetActive(false);
    }

    void OnYesButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

}
