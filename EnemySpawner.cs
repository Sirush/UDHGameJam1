using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyprefab;
    [SerializeField] private float _minSpawnRate = 5f;
    [SerializeField] private float _maxSpawnRate = 15f;

    private float _nextSpawn;

    private void Update()
    {
        if (Time.time > _nextSpawn)
        {
            Instantiate(_enemyprefab, transform.position, Quaternion.identity);
            _nextSpawn = Time.time + Random.Range(_minSpawnRate, _maxSpawnRate);
        }
    }

}
