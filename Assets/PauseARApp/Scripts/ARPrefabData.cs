using UnityEngine;

[CreateAssetMenu(fileName = "ARPrefabData", menuName = "AR/PrefabData", order = 1)]
public class ARPrefabData : ScriptableObject
{
    public GameObject prefab; // AR prefab (e.g., planet or star)
    public int count; // number of instances to initialize
    public float spawnInterval = 2f; // time between spawns
}

