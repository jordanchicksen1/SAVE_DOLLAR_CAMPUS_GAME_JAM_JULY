using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpforce;
    private bool isFacingRight = true;
  

    private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

     if (Input.GetButtonDown("Jump") && IsGrounded() ) 
        {
        rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }

     if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f) 
        {
        rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded() 
    {
      return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
    }

    private void Flip() 
    {
    if (isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f) 
        {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x*= -1f;
        transform.localScale = localScale;
        }
    }
}
