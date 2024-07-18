using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class BreathingGuide : MonoBehaviour
{
    public TMP_Text promptText;
    public float minSize = 2f; // min size of sphere
    public float maxSize = 5f; // max size of sphere
    public float cycleDuration = 16.0f; // duration of one breathing cycle
    private float timer = 0f; // timer to track current phase of the cycle

    // Start is called before the first frame update
    void Start()
    {
        // initialise sphere size
        transform.localScale = new Vector3(minSize, minSize, minSize);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // increment timer by the time since last frame
        if (timer >= cycleDuration)
        {
            timer -= cycleDuration; // reset timer after completing one cycle
        }

        float t = timer / cycleDuration; // normalize timer to range [0, 1]

        // determine current phase of breathing cycle & update text prompt
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

        // animate sphere based on current phase of breathing cycle
        if (t < 0.25f) // inhale
        {
            transform.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), t * 4);
        }
        else if (t >= 0.5f && t < 0.75f) // exhale
        {
            transform.localScale = Vector3.Lerp(new Vector3(maxSize, maxSize, maxSize), new Vector3(minSize, minSize, minSize), (t - 0.5f) * 4);
        }
        else if (t >= 0.25f && t < 0.5f) // hold after inhale
        {
            transform.localScale = new Vector3(maxSize, maxSize, maxSize);
        }
        else if (t >= 0.75f) // hold after exhale
        {
            transform.localScale = new Vector3(minSize, minSize, minSize);
        }
    }
}