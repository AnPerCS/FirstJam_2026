using Unity.Behavior;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private Transform PlayerTransform;
    
    HealthComponent healthComponent;
    BehaviorGraphAgent behaviorAgent;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        behaviorAgent = GetComponent<BehaviorGraphAgent>();
        behaviorAgent.BlackboardReference.SetVariableValue("PlayerTransform", PlayerTransform);
    }

    private void Start()
    {
        healthComponent.SetMaxHealth(maxHealth);
        healthComponent.ResetHealth();
    }

    private void OnDamaged()
    {
        //play damage animation
    }

    private void OnDeath()
    {
        Destroy(gameObject);
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
