using UnityEngine;
using UnityEngine.Pool;

public class EnemyProjectilePool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    private IObjectPool<GameObject> pool;

    public IObjectPool<GameObject> Pool
    { get { return pool; } }

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(
            () => CreateEnemy(),
            (obj) =>
            {
                obj.SetActive(true);
                obj.GetComponent<Collider2D>().enabled = true;
                obj.GetComponent<MoveUp>().enabled = true;
            },
            (obj) => obj.SetActive(false),
            (obj) => Destroy(obj)
            );
    }

    GameObject CreateEnemy()
    {
        GameObject enemy = Instantiate(prefab);
        enemy.GetComponent<EnemyProjectile1>().SetPool(pool);
        return enemy;
    }
}
