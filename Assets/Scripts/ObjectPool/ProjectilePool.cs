using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] int defaultCapacity = 10;
    [SerializeField] int maxSize = 20;

    IObjectPool<GameObject> objectPool;

    public IObjectPool<GameObject> Pool => objectPool;

    private void Awake()
    {
        
        objectPool = new ObjectPool<GameObject>(
            CreateProjectile,
            OnGetFromPool,
            OnReleaseToPool,
            OnDestroyPooledObject,
            true, defaultCapacity, maxSize);
    }

    GameObject CreateProjectile()
    {
        GameObject obj = Instantiate(prefab);
        obj.GetComponent<Projectile>().SetPool(objectPool);
        return obj;
    }

    void OnGetFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    void OnReleaseToPool(GameObject obj)
    {
        
        obj.SetActive(false);
    }

    void OnDestroyPooledObject(GameObject obj)
    {
        Destroy(obj);
    }
}