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
        // Calcula el rango en el que se instanciarán los objetos.
        float minX = transform.position.x - (spacing * (numberOfObjectsToSpawn - 1)) / 2;
        float maxX = transform.position.x + (spacing * (numberOfObjectsToSpawn - 1)) / 2;

        // Itera para instanciar cada objeto en el rango.
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            float xPos = Mathf.Lerp(minX, maxX, (float)i / (numberOfObjectsToSpawn - 1));
            Vector3 spawnPosition = new Vector3(xPos, transform.position.y, transform.position.z);
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}