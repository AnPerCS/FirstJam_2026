using UnityEngine;
using UnityEngine.Pool;

public class EnemyProjectile1 : MonoBehaviour
{
    IObjectPool<GameObject> pool;

    [SerializeField] private float damage = 1f;

    public void SetPool(IObjectPool<GameObject> pool)
    { 
        this.pool = pool; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(damage);
        }

        if (!collision.gameObject.CompareTag("EnemyProjectile") && !collision.gameObject.CompareTag("Enemy"))
        {
            pool.Release(gameObject);
        }
    }
}
