using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] GameObject prefab;

    IObjectPool<GameObject> objectPool;

    public IObjectPool<GameObject> ObjectPool
    {
        get { return objectPool; }
    }

    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateProjectile, OnGetFromPool, OnReleaseToPool);
    }

    GameObject CreateProjectile()
    {
        GameObject obj = Instantiate(prefab);
        prefab.GetComponent<Projectile>().objectPool = objectPool;
        return obj;
    }

    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnReleaseToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Release(this.gameObject);
    }


    // PlayerScript
    // [serialize] projectile pool


    // Gameobj obj = objectPool.Get()


    // objectpool.Release(this.gameObject)
}
