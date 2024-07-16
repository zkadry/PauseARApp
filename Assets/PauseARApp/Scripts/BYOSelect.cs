using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BYOSelect : MonoBehaviour
{
    public Button backButton;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        backButton.onClick.AddListener(OnBackButtonClick);
        
    }

    void OnBackButtonClick()
    {
        // Load the Experience Select scene
        SceneManager.LoadScene("ChooseYourExperience");
    }

}
