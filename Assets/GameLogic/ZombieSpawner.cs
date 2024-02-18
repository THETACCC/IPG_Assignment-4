using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnTimeInterval = 5f; 
    public float timeDecreaseAmount = 0.2f; 
    public float minimumTimeInterval = 1f; 
    public Vector2 spawnAreaMin = new Vector2(-10, -10);
    public Vector2 spawnAreaMax = new Vector2(10, 10);

    void Start()
    {
        SpawnObject(); 
    }

    void SpawnObject()
    {

        Vector3 spawnPosition = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            3, 
            Random.Range(spawnAreaMin.y, spawnAreaMax.y)
        );


        Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

 
        spawnTimeInterval = Mathf.Max(spawnTimeInterval - timeDecreaseAmount, minimumTimeInterval);


        Invoke("SpawnObject", spawnTimeInterval);
    }
}
