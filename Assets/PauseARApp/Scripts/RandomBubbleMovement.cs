using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBubbleMovement : MonoBehaviour
{
    public float floatSpeed = 0.5f; // Speed at which the bubble floats
    public float floatAmplitude = 1f; // Amplitude of floating motion

    private Vector3 startPosition;
    private float randomOffset;

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Random offset for variation
    }

    void Update()
    {
        // Create floating motion
        float yOffset = Mathf.Sin(Time.time * floatSpeed + randomOffset) * floatAmplitude;
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}
