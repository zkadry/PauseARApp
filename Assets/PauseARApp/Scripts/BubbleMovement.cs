using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleMovement : MonoBehaviour
{
    public float speed = 0.5f;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(
            Random.Range(-1f, 1f), // random horizontal movement
            Random.Range(-0.5f, 1f), // random vertical movement
            Random.Range(-1f, 1f)); // random z axis movement
        direction.Normalize(); // ensure consistent movement speed
    }

    // Update is called once per frame
    void Update()
    {
        // move bubble in random direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
