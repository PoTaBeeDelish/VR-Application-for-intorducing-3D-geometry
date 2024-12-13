using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismBuilder : MonoBehaviour
{
    // Array of prefab GameObjects to spawn
    public GameObject[] prefabs;

    // Time between each prefab spawn
    public float spawnInterval = 0.5f;

    // Number of columns and rows for orderly spawning
    public int Panjang;
    public int Lebar;
    public int Tinggi;

    // Starting position for orderly spawning
    public GameObject spawnStartObject;

    public Vector3 newScale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        // Start the spawning process
        StartCoroutine(SpawnPrefabsOrderly());
    }

    // Coroutine to spawn prefabs at intervals in an orderly manner
    IEnumerator SpawnPrefabsOrderly()
    {
        int jumlah = Panjang * Lebar * Tinggi;
        for (int i = 0; i < Tinggi; i++)
        {
            GameObject prefabToSpawn = prefabs[0];

            // Calculate position for orderly spawning
            Vector3 spawnPosition = GetOrderlyPosition(i);

            // Instantiate the prefab at the calculated position
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.Euler(90,0,0));


            // Change the scale of the instantiated prefab
            spawnedObject.transform.localScale = newScale;

            // Wait for the defined interval before spawning the next prefab
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Function to calculate the position in an orderly grid
    Vector3 GetOrderlyPosition(int index)
    {
        Vector3 startPosition = spawnStartObject.transform.position;
        float distanceBetweenPrefabs = newScale.z;  // Distance between spawned prefabs

        int indexY = index;
        // Calculate the spawn position based on row, column, and distance between prefabs
        Vector3 position = new Vector3(
            startPosition.x,
            startPosition.y + indexY * distanceBetweenPrefabs,
            startPosition.z
        );

        return position;
    }
}
