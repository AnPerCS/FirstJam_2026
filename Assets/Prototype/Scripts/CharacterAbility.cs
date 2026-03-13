using UnityEngine;
using System.Collections;

public class CharacterAbility : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shotPoint;
    private Transform bulletPos;
    private GameObject bulletInstance;
    private bool isShooting = false;
    [SerializeField] private Transform pivotTransform;
    public float rotationSensitivity = 20f;
    public float bulletSpeed = 10f;
    public Transform prevPosition;
    [SerializeField] private GameObject tree;
    private bool isResizing = false;
    private Vector3 targetSize = Vector3.one;
    private Vector3 treeSize;
    [SerializeField] private ProjectilePool pool;



    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        HandleRotation();

        if (Input.GetMouseButton(0) && !isShooting)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetMouseButtonDown(1))
        {
            Teleport();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            GetSize();
        }

        //if (isTeleporting) return;
        //SavePosition();
    }

    void HandleRotation()
    {
        float scroll = Input.mouseScrollDelta.y;
        if (scroll != 0 && pivotTransform != null)
        {
            pivotTransform.Rotate(0, 0, scroll * rotationSensitivity);
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;

        bulletInstance = pool.Pool.Get();

        bulletInstance.transform.position = shotPoint.position;
        bulletInstance.transform.rotation = Quaternion.identity;

        Rigidbody2D bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = Vector2.zero;
        bulletRb.AddForce(pivotTransform.right * bulletSpeed, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }

    void Teleport()
    {
        if (bulletInstance == null || !bulletInstance.activeSelf) return;
        transform.position = bulletInstance.transform.position;
        pool.Pool.Release(bulletInstance);
        bulletInstance = null;
    }

    void GetSize()
    {
        if (targetSize != null)
        {
            transform.localScale = targetSize;
            treeSize = targetSize;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            targetSize = other.transform.localScale;
            Destroy(other.gameObject, 2f);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tree") && transform.localScale != Vector3.one)
        {
            if (isResizing) return;
            isResizing = true;
            Vector3 currentTreeScale = other.transform.localScale;

            currentTreeScale.y += treeSize.y;

            other.transform.localScale = currentTreeScale;

            ResetSize();
            isResizing = false;
        }
    }


    void ResetSize()
    {
        transform.localScale = Vector3.one;
        targetSize = Vector3.one;
    }

}

