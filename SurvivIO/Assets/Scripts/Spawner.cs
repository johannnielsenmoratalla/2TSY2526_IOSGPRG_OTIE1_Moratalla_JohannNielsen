using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ammos;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject enemies;

    private void Start()
    {

        for (int i = 0; i < 20; i++)
        {
            float randomX = Random.Range(-19.21f, 19.21f);
            float randomY = Random.Range(-14.81f, 14.81f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            GameObject objectToSpawn = Random.value < 0.7f ? GetRandomObject(ammos) : GetRandomObject(weapons);

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            float randomX = Random.Range(-19.21f, 19.21f);
            float randomY = Random.Range(-14.81f, 14.81f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

            Instantiate(enemies, spawnPosition, Quaternion.identity);
        }
    }

    private GameObject GetRandomObject(GameObject[] objectArray)
    {
        // Get a random object from the array
        int randomIndex = Random.Range(0, objectArray.Length);
        return objectArray[randomIndex];
    }
}