using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public ParticleSystem popEffect; // assign particle system in unity for pop effect

    void OnMouseDown()
    {

        // play pop effect
        var effect = Instantiate(popEffect, transform.position, Quaternion.identity);
        effect.Play();


        // destroy bubble
        Destroy(gameObject);
    }

}
