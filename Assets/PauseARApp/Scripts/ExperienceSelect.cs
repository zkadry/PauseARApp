using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExperienceSelect : MonoBehaviour
{
    public Button walkButton;
    public Button breakButton;
    public Button anywhereButton;
    public Button byoButton;
    public Button reminderButton;

       // Start is called before first frame update
    void Start()
    {
        // Assign button click listeners
        walkButton.onClick.AddListener(OnWalkButtonClick);
        breakButton.onClick.AddListener(OnBreakButtonClick);
        anywhereButton.onClick.AddListener(OnAnywhereButtonClick);
        byoButton.onClick.AddListener(OnBYOButtonClick);
        reminderButton.onClick.AddListener(OnReminderButtonClick);
    }

    void OnWalkButtonClick()
    {
        // load Walk mode description scene
        SceneManager.LoadScene("WalkSelect");
    }

    void OnBreakButtonClick()
    {
        // load Bre mode description scene
        SceneManager.LoadScene("ActivitySelect");
    }

    void OnAnywhereButtonClick()
    {
        // load Anywhere mode description scene
        SceneManager.LoadScene("AnywhereSelect");
    }

    void OnBYOButtonClick()
    {
        // load BYO mode description scene
        SceneManager.LoadScene("BYOSelect");
    }

    void OnReminderButtonClick()
    {
        // load notification reminder scene
        SceneManager.LoadScene("NotificationTimer");
    }
}