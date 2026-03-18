using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator animator;

    Vector3 lastPosition;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;

        animator.SetFloat("XVelocity", velocity.x);
        animator.SetFloat("YVelocity", velocity.y);
    }
}
