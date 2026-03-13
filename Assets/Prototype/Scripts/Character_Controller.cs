using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float rayLength = 2.5f;
    private float moveInput;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    [SerializeField] private bool isGoalReached = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //moveInput = Input.GetAxisRaw("Horizontal");
        CheckGround();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        if (isGoalReached)
        {
            rb.linearVelocity = new Vector2(0, speed);
        }
       
    }
    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, rayLength, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
    }

    public void GoUp(bool isReached)
    {
        isGoalReached = isReached;
    }

   
}
