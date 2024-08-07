using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BreathingMarker : MonoBehaviour
{
    public GameObject bubblePrefab; // Reference to bubble prefab
    public TMP_Text promptText; // Text prompt for breathing instructions
    public float minSize = 2f; // Min size of bubble
    public float maxSize = 5f; // Max size of bubble
    public float cycleDuration = 16.0f; // Duration of one breathing cycle
    private float timer = 0f; // Timer to track current phase of cycle

    private GameObject bubbleObject; // Reference to bubble GameObject

    void Start()
    {
        // Initialize and start breathing activity
        StartCoroutine(BreathingCycle());
    }

    IEnumerator BreathingCycle()
    {
        while (true) // Loop indefinitely
        {
            timer = 0f; // Reset timer

            // Instantiate bubble
            bubbleObject = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

            while (timer < cycleDuration)
            {
                float t = timer / cycleDuration; // Normalize timer to range [0, 1]

                // Update text prompt and bubble behavior
                UpdateBreathingPrompt(t);
                AnimateBubble(t);

                timer += Time.deltaTime; // Increment timer by time since last frame
                yield return null; // Wait until next frame
            }

            // Optionally, you can add a small delay before starting next cycle
            yield return new WaitForSeconds(1f);

            // Destroy bubble after cycle
            if (bubbleObject != null)
            {
                Destroy(bubbleObject);
            }
        }
    }

    void UpdateBreathingPrompt(float t)
    {
        if (t < 0.25f)
        {
            promptText.text = "breathe in.";
        }
        else if (t >= 0.25f && t < 0.5f)
        {
            promptText.text = "hold breath.";
        }
        else if (t >= 0.5f && t < 0.75f)
        {
            promptText.text = "breathe out.";
        }
        else
        {
            promptText.text = "hold breath.";
        }
    }

    void AnimateBubble(float t)
    {
        if (bubbleObject != null)
        {
            Transform bubbleTransform = bubbleObject.transform;
            
            if (t < 0.25f) // inhale
            {
                // Bubble growth logic
                float scale = Mathf.Lerp(minSize, maxSize, t * 4);
                bubbleTransform.localScale = new Vector3(scale, scale, scale);
            }
            else if (t >= 0.5f && t < 0.75f) // exhale
            {
                // Bubble shrinkage logic
                float scale = Mathf.Lerp(maxSize, minSize, (t - 0.5f) * 4);
                bubbleTransform.localScale = new Vector3(scale, scale, scale);
            }
            else if (t >= 0.25f && t < 0.5f) // hold after inhale
            {
                bubbleTransform.localScale = new Vector3(maxSize, maxSize, maxSize);
            }
            else if (t >= 0.75f) // hold after exhale
            {
                bubbleTransform.localScale = new Vector3(minSize, minSize, minSize);
            }
        }
    }
}
