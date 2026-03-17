using System.Collections;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemySpawnerPool[] enemyPoolObjects;
    [SerializeField] private float minSpawnTime = 1f;
    [SerializeField] private float maxSpawnTime = 3f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            print("Spawning");
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int chosenIndex = Random.Range(0, enemyPoolObjects.Length);
        GameObject enemy = enemyPoolObjects[chosenIndex].Pool.Get();
        enemy.transform.position = transform.position;
    }
}
