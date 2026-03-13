using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    private IObjectPool<GameObject> _pool;

    public void SetPool(IObjectPool<GameObject> pool)
    {
        _pool = pool;
    }

    private void OnEnable()
    {
        Invoke(nameof(ReturnToPool), 5f);
    }

    private void ReturnToPool()
    {
        if (_pool != null)
        {
            _pool.Release(gameObject);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            ReturnToPool();
        }
    }

}



