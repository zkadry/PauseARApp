using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowingBubbles : MonoBehaviour
{
    private Vector3 direction;
    private float speed;
    public float lifeTime = 5.0f;

    public void Initialize(Vector3 direction, float speed)
    {
        this.direction = direction.normalized;
        this.speed = speed;
        Destroy(gameObject, lifeTime); // destroy bubble after lifetime expires
    }

    void Update()
    {
        // move bubble away from screen
        transform.Translate(direction * speed * Time.deltaTime);
    }
}