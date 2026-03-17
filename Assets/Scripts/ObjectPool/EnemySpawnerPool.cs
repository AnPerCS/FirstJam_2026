using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawnerPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private IObjectPool<GameObject> pool;

    public IObjectPool<GameObject> Pool
        { get { return pool; } }

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(
            () => CreateEnemy(),
            (obj) => obj.SetActive(true),
            (obj) => obj.SetActive(false),
            (obj) => Destroy(obj)
            );
    }

    GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(prefab);
        enemy.GetComponent<Enemy>().SetPool(pool);
        return enemy;
    }
}
