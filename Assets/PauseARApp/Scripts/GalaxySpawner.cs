using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalaxySpawner : MonoBehaviour
{
    public ARPrefabData[] arPrefabsData; // Array to hold AR prefab data
    public Vector3 spawnAreaSize = new Vector3(10, 10, 10); // Size of the spawn area

    private List<GameObject> spawnedObjects = new List<GameObject>(); // List to hold references to spawned objects
    private Dictionary<GameObject, Coroutine> activeCoroutines = new Dictionary<GameObject, Coroutine>();

    // Start is called before the first frame update
    void Start()
    {
        InitializeObjects();
        StartSpawning();
    }

    void InitializeObjects()
    {
        spawnedObjects.Clear(); // Clear existing references
        foreach (var arPrefabData in arPrefabsData)
        {
            for (int i = 0; i < arPrefabData.count; i++)
            {
                Vector3 spawnPosition = transform.position + new Vector3(
                    Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                    Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                    Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

                GameObject instance = Instantiate(arPrefabData.prefab, spawnPosition, Quaternion.identity);
                spawnedObjects.Add(instance);
            }
        }
    }

    void StartSpawning()
    {
        foreach (var arPrefabData in arPrefabsData)
        {
            Coroutine coroutine = StartCoroutine(SpawnObjects(arPrefabData));
            activeCoroutines[arPrefabData.prefab] = coroutine;
        }
    }

    IEnumerator SpawnObjects(ARPrefabData arPrefabData)
    {
        while (true)
        {
            yield return new WaitForSeconds(arPrefabData.spawnInterval);

            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                Random.Range(-spawnAreaSize.y / 2, spawnAreaSize.y / 2),
                Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

            GameObject instance = Instantiate(arPrefabData.prefab, spawnPosition, Quaternion.identity);
            spawnedObjects.Add(instance);
        }
    }

    // Optional: Method to stop spawning objects if needed
    public void StopSpawning()
    {
        foreach (var kvp in activeCoroutines)
        {
            StopCoroutine(kvp.Value);
        }
        activeCoroutines.Clear();
    }
}
