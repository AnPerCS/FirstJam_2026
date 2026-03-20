using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private float upSpeed = 3f;
    
    HealthComponent healthComponent;

    public static event System.Action OnWin;

    private void Awake()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.SetMaxHealth(maxHealth);
        healthComponent.ResetHealth();
    }

    public void _OnWin()
    {
        GetComponent<HealthComponent>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        StartCoroutine(MoveUpRoutine());
        StartCoroutine(EndLevelRoutine());

        OnWin?.Invoke();
    }

    private IEnumerator MoveUpRoutine()
    {
        while (true)
        {
            Vector3 newPos = new Vector3(0, 1, 0);
            transform.position += newPos * upSpeed * Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator EndLevelRoutine()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("EndScene");
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
