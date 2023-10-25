using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int numberOfObjectsToSpawn = 5;
    public float spacing = 2.0f;
    public float spawnInterval = 2.0f;

    private void Start()
    {
        // Llama al método SpawnObject repetidamente cada spawnInterval segundos.
        InvokeRepeating("SpawnObject", 0.0f, spawnInterval);
    }

    private void SpawnObject()
    {
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
}