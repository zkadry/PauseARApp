using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ARLocation;

public class ActivityLocationTrigger : MonoBehaviour
{
    public AbstractLocationProvider locationProvider;
    public Location targetLocation;
    public float activationRadius = 5.0f; // radius within which activity is triggered
    public LocationActivityUIManager uiManager;

    private Location currentLocation; // device's current location

    // Start is called before first frame update
    void Start()
    {
        StartCoroutine(UpdateLocation());
    }

    IEnumerator UpdateLocation()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f); // update location every second
            
            if (locationProvider.Status == LocationProviderStatus.Started)
            {
                // get current location from location provider
                var locationReading = locationProvider.CurrentLocation;
                currentLocation = locationReading.ToLocation();

                // check if current location is within activation radius
                CheckLocation();
            }
        }
    }

    // check if current location is within activation radius of target location
    void CheckLocation()
    {
        var distance = Location.HorizontalDistance(currentLocation, targetLocation);
        
        if (distance <= activationRadius)
        {
            ShowUI(); // show UI if within radius
        }
        else
        {
            HideUI(); // hide UI if outside radius
        }
    }

    // method to show UI and set up button actions
    void ShowUI()
    {
        if (uiManager != null)
        {
            uiManager.ShowUI(); // display UI panel

            // set up actions for buttons
            uiManager.SetActivity1Action(() => PerformActivity("BubbleActivity"));
            uiManager.SetActivity2Action(() => PerformActivity("BreathingActivity"));
            uiManager.SetSkipAction(() => HideUI());
        }
        else
        {
            Debug.LogError("UI Manager is not assigned.");
        }
    }

    // method to hide UI if activity skipped
    void HideUI()
    {
        uiManager.HideUI(); // hide UI panel
    }

    // Method to perform specified activity and hide UI
    void PerformActivity(string activity)
    {
        Debug.Log($"{activity} triggered!");

        if (activity == "BubbleActivity")
        {
            DoActivity1();
        }
        else if (activity == "BreathingActivity")
        {
            DoActivity2();
        }

        HideUI(); // Hide UI after performing activity
    }

    private void DoActivity1()
    {
        WalkBubbleActivity.Instance.StartActivity();
    }

    private void DoActivity2()
    {
        WalkBreathingActivity.Instance.StartActivity(); 
    }

}
