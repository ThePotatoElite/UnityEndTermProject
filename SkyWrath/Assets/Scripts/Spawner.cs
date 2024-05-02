using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Spawner : MonoBehaviour
{
    [SerializeField] private string[] AddressableEnemiesLabels;
    [SerializeField] private float TimeToSpawnMin = 1;
    [SerializeField] private float TimeToSpawnMax = 3;

    private float _spawnTimer;

    private void Start()
    {
        
    }

    private void Update()
    {
        SpawnerBehavior();
    }


    private async void SpawnAsync()
    {
        AsyncOperationHandle<GameObject> handle =
            Addressables.LoadAssetAsync<GameObject>(
                AddressableEnemiesLabels[Random.Range(0, AddressableEnemiesLabels.Length)]);

        await handle.Task;

        Instantiate(handle.Result, transform.position, Quaternion.identity);
        
        Addressables.Release(handle);
    }

    private void SpawnerBehavior()
    {
        if (_spawnTimer > 0f)
            _spawnTimer -= Time.deltaTime;
        else
        {
            SpawnAsync();
            _spawnTimer = Random.Range(TimeToSpawnMin, TimeToSpawnMax);
        }
    }
}
