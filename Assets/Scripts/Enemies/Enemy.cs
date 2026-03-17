using Unity.Behavior;
using UnityEngine;
using UnityEngine.Pool;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected Transform PlayerTransform;
    
    protected HealthComponent healthComponent;
    protected BehaviorGraphAgent behaviorAgent;

    protected IObjectPool<GameObject> pool;

    protected virtual void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        behaviorAgent = GetComponent<BehaviorGraphAgent>();
        PlayerTransform = GameObject.FindWithTag("Player").transform;
        behaviorAgent.BlackboardReference.SetVariableValue("PlayerTransform", PlayerTransform);
    }

    public void SetPool(IObjectPool<GameObject> pool)
    { 
        this.pool = pool; 
    }

    private void Start()
    {
        healthComponent.SetMaxHealth(maxHealth);
        healthComponent.ResetHealth();
    }

    protected virtual void OnDamaged()
    {
        //play damage animation
    }

    protected virtual void OnDeath()
    {
        pool.Release(gameObject);
    }

    private void OnEnable()
    {
        healthComponent.OnDamaged += OnDamaged;
        healthComponent.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        healthComponent.OnDamaged -= OnDamaged;
        healthComponent.OnDeath -= OnDeath;
    }
}
