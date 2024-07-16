using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExperienceSelect : MonoBehaviour
{
    public Button walkButton;
    public Button breatheButton;
    public Button anywhereButton;
    public Button byoButton;

       // Start is called before the first frame update
    void Start()
    {
        // Assign the button click listeners
        walkButton.onClick.AddListener(OnWalkButtonClick);
        breatheButton.onClick.AddListener(OnBreatheButtonClick);
        anywhereButton.onClick.AddListener(OnAnywhereButtonClick);
        byoButton.onClick.AddListener(OnBYOButtonClick);
    }

    void OnWalkButtonClick()
    {
        // Load the Walk mode description scene
        SceneManager.LoadScene("WalkSelect");
    }

    void OnBreatheButtonClick()
    {
        // Load the Breathe mode description scene
        SceneManager.LoadScene("ActivitySelect");
    }

    void OnAnywhereButtonClick()
    {
        // Load the Anywhere mode description scene
        SceneManager.LoadScene("AnywhereSelect");
    }

    void OnBYOButtonClick()
    {
        // Load the BYO mode description scene
        SceneManager.LoadScene("BYOSelect");
    }
}

