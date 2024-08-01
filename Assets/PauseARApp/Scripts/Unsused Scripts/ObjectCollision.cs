using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public float floatForce = 10f; // Force applied to move the object away
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing from this object.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ensure the Rigidbody component is available
            if (rb != null)
            {
                // Calculate direction away from the user
                Vector3 directionAway = transform.position - collision.transform.position;
                directionAway.Normalize(); // Normalize to ensure a consistent force application
                
                // Apply force to the Rigidbody in the direction away from the user
                rb.AddForce(directionAway * floatForce, ForceMode.Impulse);
            }
        }
    }
}
