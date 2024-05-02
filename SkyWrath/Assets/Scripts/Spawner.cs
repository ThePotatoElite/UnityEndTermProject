using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] EnemyPrefabs;
    [SerializeField] private float TimeToSpawnMin = 1;
    [SerializeField] private float TimeToSpawnMax = 3;

    private float _spawnTimer;

    private void Update()
    {
        SpawnerBehavior();
    }


    private void Spawn()
    {
        Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], gameObject.transform.position,
            Quaternion.identity);
    }

    private void SpawnerBehavior()
    {
        if (_spawnTimer > 0f)
            _spawnTimer -= Time.deltaTime;
        else
        {
            Spawn();
            _spawnTimer = Random.Range(TimeToSpawnMin, TimeToSpawnMax);
        }
    }
}
