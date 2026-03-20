using System.Collections;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerPool[] enemyPoolObjects;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;
    [SerializeField] private float waveTimer = 15f;
    [SerializeField] private float waveInterval = 10f;

    bool canSpawn = false;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(WaveRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            while (canSpawn)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
                print("Spawning");
                SpawnEnemy();
            }
            yield return null;
        }
    }

    private IEnumerator WaveRoutine()
    {
        while (true)
        {
            canSpawn = true;
            yield return new WaitForSeconds(waveTimer);
            canSpawn = false;
            yield return new WaitForSeconds(waveInterval);
        }
    }

    private void SpawnEnemy()
    {
        int chosenIndex = Random.Range(0, enemyPoolObjects.Length);
        GameObject enemy = enemyPoolObjects[chosenIndex].Pool.Get();
        enemy.transform.position = transform.position;
    }
}
