using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleLifetime : MonoBehaviour
{
    public float lifespan = 8f; // Time before bubble disappears

    void Start()
    {
        // Destroy the bubble after its lifespan
        Destroy(gameObject, lifespan);
    }
}

