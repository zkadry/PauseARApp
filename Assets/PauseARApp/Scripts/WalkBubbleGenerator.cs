using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBubbleGenerator : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float minSpawnInterval = 3f; // minimum time between spawns
    public float maxSpawnInterval = 1f; // maximum time between spawns

    void Start()
    {
        // start spawning new bubbles
        StartCoroutine(SpawnBubbles());
    }

    IEnumerator SpawnBubbles()
    {
        while (true) // continuous spawning loop
        {
            // wait for random interval between spawns
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            // instantiate new bubble at current position
            Instantiate(bubblePrefab, transform.position, Quaternion.identity);
        }
    }
}
