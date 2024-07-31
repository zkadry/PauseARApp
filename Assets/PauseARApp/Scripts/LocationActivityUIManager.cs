using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LocationActivityUIManager : MonoBehaviour
{
    // reference to UI panel 
    public GameObject uiPanel;

    // references to buttons for two activities and skip option
    public Button activity1Button;
    public Button activity2Button;
    public Button skipButton;

    // show UI panel
    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    // hide UI panel
    public void HideUI()
    {
        uiPanel.SetActive(false);
    }

    // Set up action for Activity 1 button
    public void SetActivity1Action(UnityEngine.Events.UnityAction action)
    {
        activity1Button.onClick.RemoveAllListeners(); // remove any previous listeners
        activity1Button.onClick.AddListener(action); // add new action to button
    }

    // Set up action for Activity 2 button
    public void SetActivity2Action(UnityEngine.Events.UnityAction action)
    {
        activity2Button.onClick.RemoveAllListeners(); 
        activity2Button.onClick.AddListener(action); 
    }
    
    // Set up action for Skip button
    public void SetSkipAction(UnityEngine.Events.UnityAction action)
    {
        skipButton.onClick.RemoveAllListeners(); 
        skipButton.onClick.AddListener(action); 
    }
}

