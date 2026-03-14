using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float rotationSensitivity = 20f;

    [Header("Detection Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 1.1f;
    [SerializeField] private Transform pivotTransform;

    [Header("Projectile Settings")]
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float fireRate = 0.2f;

    [Header("Pool References")]
    [SerializeField] private ProjectilePool projectilePool; 
    [SerializeField] private VFXPool teleportVFXPool;

    private GameObject latestProjectile;
    private bool isShooting;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        if (Input.GetMouseButton(0) && !isShooting)
        {
            StartCoroutine(ShootRoutine());
        }

        if (Input.GetMouseButtonDown(1))
        {
            Teleport();
        }
    }

    private IEnumerator ShootRoutine()
    {
        isShooting = true;

        GameObject projectileObj = projectilePool.Pool.Get();
        projectileObj.transform.SetPositionAndRotation(shotPoint.position, shotPoint.rotation);
        projectileObj.transform.localScale = transform.localScale; // change projectile size to current size 

        if (projectileObj.TryGetComponent(out Projectile proj))
        {
            proj.Launch();
        }

        latestProjectile = projectileObj;

        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }

    private void Teleport()
    {
        if (latestProjectile == null || !latestProjectile.activeSelf) return;

        GameObject smokeStart = teleportVFXPool.GetPool(0).Get();
        smokeStart.transform.position = transform.position;

        transform.position = latestProjectile.transform.position;
        rb.linearVelocity = Vector2.zero;

        GameObject smokeEnd = teleportVFXPool.GetPool(1).Get();
        smokeEnd.transform.position = transform.position;

        projectilePool.Pool.Release(latestProjectile);
        latestProjectile = null;
    }

    void FixedUpdate()
    {
        CheckGround();

        if (jumpRequested)
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        jumpRequested = false;
    }

    private void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayLength, isGrounded ? Color.green : Color.red);
    }

    private void HandleRotation()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (Mathf.Abs(scroll) > 0.01f && pivotTransform != null)
        {
            pivotTransform.Rotate(0, 0, scroll * rotationSensitivity);
        }
    }
}