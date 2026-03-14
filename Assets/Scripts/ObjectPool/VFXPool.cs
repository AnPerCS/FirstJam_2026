using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class VFXPool : MonoBehaviour
{
    //(0 = Default Smoke, 1 = "O" Shape Smoke)
    [SerializeField] private GameObject[] prefabs;

    private Dictionary<int, IObjectPool<GameObject>> pools = new Dictionary<int, IObjectPool<GameObject>>();

    public IObjectPool<GameObject> GetPool(int index)
    {
        if (!pools.ContainsKey(index))
        {
            
            pools[index] = new ObjectPool<GameObject>(
                () => CreateVFX(index),
                (obj) => obj.SetActive(true),
                (obj) => obj.SetActive(false),
                (obj) => Destroy(obj),
                true, 10, 20);
        }
        return pools[index];
    }

    GameObject CreateVFX(int index)
    {
        GameObject obj = Instantiate(prefabs[index]);
        if (obj.TryGetComponent(out SmokeItem item))
        {
            item.SetPool(pools[index]);
        }
        return obj;
    }
}