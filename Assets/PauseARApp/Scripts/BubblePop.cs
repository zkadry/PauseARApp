using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public ParticleSystem popEffect; // assign particle system in unity for pop effect

    void OnMouseDown()
    {
        // play pop effect
        Instantiate(popEffect, transform.position, Quaternion.identity);

        // destroy bubble
        Destroy(gameObject);
    }

}
