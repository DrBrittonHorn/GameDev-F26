using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public Vector3 playerStart;
    [Header("Movement")]
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    float horizMovement;
    [Header("Jumping")]
    public float jumpPower = 10f;
    public int maxJumps = 2;
    private int jumpsRemaining;

    [Header("GroundCheck")]
    public Transform groundCheckPos;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.05f);
    public LayerMask groundLayer;

    [Header("Gravity")]
    public float baseGravity = 2f;
    public float maxFallSpeed = 15f;
    public float fallSpeedMult = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(horizMovement*moveSpeed, rb.linearVelocityY);
        GravityOverride();
    }

    private void GravityOverride()
    {
        if (rb.linearVelocityY < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMult;
            rb.linearVelocity = new Vector2(rb.linearVelocityX,
                Mathf.Max(rb.linearVelocityY, -maxFallSpeed));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    void OnMove(InputValue value)
    {
        horizMovement = value.Get<float>();
    }

    void OnJump(InputValue value)
    {
        checkGrounded();
        if (jumpsRemaining > 0)
        {
            if (value.isPressed)
                {
                    rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpPower);
                    jumpsRemaining--;
                }
            else
                rb.linearVelocity *= new Vector2(1, 0.5f);
        }
    }

    private void checkGrounded()
    {
        if(Physics2D.OverlapBox(groundCheckPos.position, groundCheckSize, 0, groundLayer))
        {
            jumpsRemaining = maxJumps;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(groundCheckPos.position, groundCheckSize);     
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {//collision.gameObject;
            transform.position = playerStart;
        }
    }
}
