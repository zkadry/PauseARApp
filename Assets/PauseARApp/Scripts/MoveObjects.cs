using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public float moveDistance = 1f; // How far the object will move
    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is Ended
            if (touch.phase == TouchPhase.Ended)
            {
                // Convert touch position to world position
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // If the ray hits the object
                    if (hit.transform == transform)
                    {
                        // Move the object by moveDistance units
                        transform.position = initialPosition + new Vector3(moveDistance, 0, 0);
                        
                        // Update the initial position to the new position
                        initialPosition = transform.position;
                    }
                }
            }
        }
    }
}


