using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksBuilder : MonoBehaviour
{
    // Array of prefab GameObjects to spawn
    public GameObject[] prefabs;

    // Time between each prefab spawn
    public float spawnInterval = 0.01f;

    // Number of columns and rows for orderly spawning
    public int Panjang;
    public int Lebar;
    public int Tinggi;
    public float distanceBetweenPrefabs = 0.1f;  // Distance between spawned prefabs

    // Starting position for orderly spawning
    public GameObject spawnStartObject;
    private Vector3 spawnLoc;

    // List to keep track of spawned objects
    private List<GameObject> spawnedObjects = new List<GameObject>();

    // Coroutine reference to control the spawning process
    private Coroutine spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        if(Panjang*Lebar*Tinggi <= 100)
        {
            spawnInterval = 0.4f;
        }
        else
        {
            spawnInterval = 0.01f;
        }
        spawnLoc = spawnStartObject.transform.position;
        spawnLoc.x = (float)(spawnLoc.x - Panjang / 2 * 0.1);
        spawnLoc.y = (float)(spawnLoc.y - (Lebar / 2) * 0.1);
        spawnLoc.z = (float)(spawnLoc.z - (Tinggi / 2) * 0.1);
        // Start the spawning process
        spawnCoroutine = StartCoroutine(SpawnPrefabsOrderly());
    }

    // Coroutine to spawn prefabs at intervals in an orderly manner
    IEnumerator SpawnPrefabsOrderly()
    {
        int jumlah = Panjang * Lebar * Tinggi;
        for (int i = 0; i < jumlah; i++)
        {
            GameObject prefabToSpawn = prefabs[0];

            // Calculate position for orderly spawning
            Vector3 spawnPosition = GetOrderlyPosition(i);

            // Instantiate the prefab at the calculated position
            GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);

            // Wait for the defined interval before spawning the next prefab
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Function to calculate the position in an orderly grid
    Vector3 GetOrderlyPosition(int index)
    {
        Vector3 startPosition = spawnLoc;

        int indexX = index % Panjang;
        int indexY = index / (Panjang * Lebar);
        int indexZ = index % (Panjang * Lebar) / Panjang;
        // Calculate the spawn position based on row, column, and distance between prefabs
        Vector3 position = new Vector3(
            spawnLoc.x + indexX * distanceBetweenPrefabs,
            spawnLoc.y + indexY * distanceBetweenPrefabs,
            spawnLoc.z + indexZ * distanceBetweenPrefabs
        );

        return position;
    }

    public void Ubah(int panjang, int lebar, int tinggi)
    {
        this.Panjang = panjang;
        this.Lebar = lebar;
        this.Tinggi = tinggi;

        // Stop the previous spawning coroutine if it's running
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }

        foreach (GameObject obj in spawnedObjects)
        {
            Destroy(obj);
        }

        // Clear the list of spawned objects
        spawnedObjects.Clear();

        Start();
    }
}
