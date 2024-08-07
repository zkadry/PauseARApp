using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePop : MonoBehaviour
{
    public ParticleSystem popEffect; // assign particle system in unity for pop effect
    public AudioClip[] popSounds; // array for popping sounds
    private AudioSource audioSource;

    void Start()
    {
        // get or add AudioSource component
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnMouseDown()
    {

        // play pop effect
        var effect = Instantiate(popEffect, transform.position, Quaternion.identity);
        effect.Play();

        // play random pop sound
        if (popSounds.Length > 0)
        {
            AudioClip selectedSound = popSounds[Random.Range(0, popSounds.Length)];
            audioSource.PlayOneShot(selectedSound);
        }


        // destroy bubble after short delay sound to play
        Destroy(gameObject, 0.05f);
    }

}
