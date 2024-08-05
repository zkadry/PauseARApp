using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMovement : MonoBehaviour
{
    public bool isOrbiting = false; // Flag to determine if the planet is orbiting
    public Vector3 orbitCenter; // Center point of the orbit
    public float orbitRadius = 5f; // Radius of the orbit
    public float orbitSpeed = 10f; // Speed of the orbit

    public float speed = 0.5f; // Linear movement speed
    public float rotationSpeedX = 20f; // Rotation speed around X axis
    public float rotationSpeedY = 20f; // Rotation speed around Y axis
    public float rotationSpeedZ = 20f; // Rotation speed around Z axis

    private Vector3 direction; // Linear movement direction
    private Vector3 rotationAxisX; // Axis to rotate around X
    private Vector3 rotationAxisY; // Axis to rotate around Y
    private Vector3 rotationAxisZ; // Axis to rotate around Z

    private float orbitAngle; // Current angle in the orbit

    // Start is called before the first frame update
    void Start()
    {
        if (isOrbiting)
        {
            // Set a random orbit center within a defined range
            orbitCenter = new Vector3(
                Random.Range(-100f, 100f),
                Random.Range(-5f, 5f), // Add Y-axis range
                Random.Range(-100f, 100f)
            );

            // Set a random starting angle for the orbit
            orbitAngle = Random.Range(0f, 360f);
        }
        else
        {
            // Randomize the movement direction
            direction = new Vector3(
                Random.Range(-1f, 1f), // Random horizontal movement
                Random.Range(-0.5f, 1f), // Random vertical movement
                Random.Range(-1f, 1f)); // Random z axis movement
            direction.Normalize(); // Ensure consistent movement speed
        }

        // Define the rotation axes
        rotationAxisX = Vector3.right; // X axis rotation
        rotationAxisY = Vector3.up; // Y axis rotation
        rotationAxisZ = Vector3.forward; // Z axis rotation
    }

    // Update is called once per frame
    void Update()
    {
        if (isOrbiting)
        {
            // Update the orbit angle based on orbit speed
            orbitAngle += orbitSpeed * Time.deltaTime;
            if (orbitAngle > 360f) orbitAngle -= 360f;

            // Calculate the new position in the orbit
            float x = orbitCenter.x + orbitRadius * Mathf.Cos(orbitAngle * Mathf.Deg2Rad);
            float z = orbitCenter.z + orbitRadius * Mathf.Sin(orbitAngle * Mathf.Deg2Rad);
            float y = orbitCenter.y + orbitRadius * Mathf.Sin(orbitAngle * Mathf.Deg2Rad); // Add Y-axis calculation
            transform.position = new Vector3(x, y, z);
        }
        else
        {
            // Move the planet in the random direction
            transform.position += direction * speed * Time.deltaTime;
        }

        // Rotate the planet around each axis
        transform.Rotate(rotationAxisX, rotationSpeedX * Time.deltaTime);
        transform.Rotate(rotationAxisY, rotationSpeedY * Time.deltaTime);
        transform.Rotate(rotationAxisZ, rotationSpeedZ * Time.deltaTime);
    }
}
