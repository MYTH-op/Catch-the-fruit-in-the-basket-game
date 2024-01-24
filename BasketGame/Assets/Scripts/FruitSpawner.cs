using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject FruitPrefab; // Assign Fruit prefab in the Inspector
    public float spawnRate = 2.0f;
    private float nextSpawnTime;
    

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnFruit();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnFruit()
    {
        float randomX = Random.Range(-8f, 8f); // Adjust the range according to your game's layout
        Vector2 spawnPosition = new Vector2(randomX, transform.position.y);

        Instantiate(FruitPrefab, spawnPosition, Quaternion.identity);
    }

    
}
