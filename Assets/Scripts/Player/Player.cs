using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    
    HealthComponent healthComponent;


    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.SetMaxHealth(maxHealth);
        healthComponent.ResetHealth();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //healthComponent.SetMaxHealth(maxHealth);
        //healthComponent.ResetHealth();
    }

    private void OnDamaged()
    {
        print("player hit");
    }

    private void OnDeath()
    {

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
