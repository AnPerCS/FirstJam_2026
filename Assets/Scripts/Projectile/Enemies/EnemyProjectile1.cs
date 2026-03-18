using UnityEngine;
using UnityEngine.Pool;

public class EnemyProjectile1 : MonoBehaviour
{
    IObjectPool<GameObject> pool;

    [SerializeField] private float damage = 1f;

    Animator animator;
    Collider2D _collider2d;
    MoveUp moveUp;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _collider2d = GetComponent<Collider2D>();
        moveUp = GetComponent<MoveUp>();
    }

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
            animator.SetTrigger("OnHit");
            GetComponent<MoveUp>().enabled = false;
            _collider2d.enabled = false;
            moveUp.enabled = false;
        }
    }

    public void OnOnHitAnimationDone()
    {
        pool.Release(gameObject);
    }
    
}
