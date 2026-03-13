using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    public IObjectPool<GameObject> objectPool;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            objectPool.Release(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
