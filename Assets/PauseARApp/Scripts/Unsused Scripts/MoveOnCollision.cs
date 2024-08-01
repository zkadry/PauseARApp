using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnCollision : MonoBehaviour
{
    public float moveDistance = 1f; // Distance to move away on collision
    public float moveSpeed = 1f; // Speed of the movement

    private Vector3 targetPosition;
    private bool isMoving = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 directionAwayFromPlayer = (transform.position - collision.transform.position).normalized;
            targetPosition = transform.position + directionAwayFromPlayer * moveDistance;
            isMoving = true;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Move towards the target position at the specified speed
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            // Stop moving when the target position is reached
            if (Vector3.Distance(transform.position, targetPosition) < 0.001f)
            {
                isMoving = false;
            }
        }
    }
}