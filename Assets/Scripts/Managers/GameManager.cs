using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isPersistingManager = false;

    public static GameManager instance;


    public EnemyProjectilePool EnemyProjectilePool;

    private void Awake()
    {
        if (isPersistingManager)
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if (!isPersistingManager)
        {
            instance = null;
        }
    }
}
