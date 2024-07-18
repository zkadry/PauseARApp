using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BreathingActivityManager : MonoBehaviour
{
    public TMP_Text promptText; // breathing prompts UI
    public GameObject breathingSphere; // reference to sphere
    public TMP_Text countdownText; // UI countdown
    public float minSize = 2f; // min size of sphere
    public float maxSize = 5f; // max size of sphere
    public float cycleDuration = 16.0f; // duration of one breathing cycle
    private float timer = 0f; // timer to track current phase of the cycle
    private bool isCountdownComplete = false; // check if countdown is complete

    void Start()
    {
        // initialize sphere size
        breathingSphere.transform.localScale = new Vector3(minSize, minSize, minSize);

        // start countdown when the scene loads
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        int count = 3; // starting number for countdown

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1); // wait for one second
            count--;
        }
        
        // clear countdown text after countdown completes
        countdownText.text = "";
        isCountdownComplete = true; // countdown is complete

        // after countdown, start breathing activity
        StartBreathingActivity();
    }

    void StartBreathingActivity()
    {
        if (!isCountdownComplete)
        {
            Debug.LogWarning("Countdown not complete. Cannot start breathing activity.");
            return;
        }

        Debug.Log("Breathing activity started");
    }

    void Update()
    {
        if (!isCountdownComplete)
        {
            // if countdown not complete, don't update breathing prompts or animate sphere
            return;
        }

        timer += Time.deltaTime; // increment timer by the time since last frame
        if (timer >= cycleDuration)
        {
            timer -= cycleDuration; // reset timer after completing one cycle
        }

        float t = timer / cycleDuration; // normalize timer to range [0, 1]

        // current phase of breathing cycle
        UpdateBreathingPrompt(t);

        // animate sphere based on current phase
        AnimateBreathingSphere(t);
    }

    void UpdateBreathingPrompt(float t)
    {
        if (t < 0.25f)
        {
            promptText.text = "Breathe In";
        }
        else if (t >= 0.25f && t < 0.5f)
        {
            promptText.text = "Hold Breath";
        }
        else if (t >= 0.5f && t < 0.75f)
        {
            promptText.text = "Breathe Out";
        }
        else
        {
            promptText.text = "Hold Breath";
        }
    }

    void AnimateBreathingSphere(float t)
    {
        if (t < 0.25f) // inhale
        {
            breathingSphere.transform.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), t * 4);
        }
        else if (t >= 0.5f && t < 0.75f) // exhale
        {
            breathingSphere.transform.localScale = Vector3.Lerp(new Vector3(maxSize, maxSize, maxSize), new Vector3(minSize, minSize, minSize), (t - 0.5f) * 4);
        }
        else if (t >= 0.25f && t < 0.5f) // hold after inhale
        {
            breathingSphere.transform.localScale = new Vector3(maxSize, maxSize, maxSize);
        }
        else if (t >= 0.75f) // hold after exhale
        {
            breathingSphere.transform.localScale = new Vector3(minSize, minSize, minSize);
        }
    }
}