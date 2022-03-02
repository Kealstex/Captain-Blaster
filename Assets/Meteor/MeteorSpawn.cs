using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject meteorPrefab;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;
    public float spawnXLimit = 6f;

    private float _timeScore = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void NextLevel()
    {
        minSpawnDelay /= 1.1f;
        maxSpawnDelay /= 1.2f;
    }

    // Update is called once per frame
    void Spawn()
    {
        var random = Random.Range(-spawnXLimit, spawnXLimit);
        var spawnPos = transform.position + new Vector3(random, 0, 0);
        Instantiate(meteorPrefab, spawnPos, Quaternion.identity);
        
        Invoke(nameof(NextLevel), 60f);
        Invoke(nameof(Spawn), Random.Range(minSpawnDelay, maxSpawnDelay));
    }
}
