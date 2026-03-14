using UnityEngine;
using UnityEngine.Pool;

public class SmokeItem : MonoBehaviour
{
    private IObjectPool<GameObject> _pool;
    private ParticleSystem _ps;

    void Awake() => _ps = GetComponent<ParticleSystem>();

    public void SetPool(IObjectPool<GameObject> pool) => _pool = pool;

    private void OnEnable()
    {
        _ps.Play();
        
        Invoke(nameof(ReturnToPool), _ps.main.duration);
    }

    private void ReturnToPool() => _pool?.Release(gameObject);

    private void OnDisable() => CancelInvoke();
}