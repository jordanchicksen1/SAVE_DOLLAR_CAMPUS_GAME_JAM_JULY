using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed;
    public float jumpforce;
    public float SecondJumpForce;
    private bool isFacingRight = true;
    //public bool CanJump = true;


    private bool DoubleJumpAbiltiy;
   
    

    private Rigidbody2D rb;
    private TrailRenderer tr;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (IsDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

       

     if (Input.GetButtonDown("Jump")) 
        {
            if (IsGrounded()) 
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce); 
                DoubleJumpAbiltiy = true;
             
            }
         else if (DoubleJumpAbiltiy) 
            {
                rb.velocity = new Vector2(rb.velocity.x, SecondJumpForce);
                DoubleJumpAbiltiy = false;
              
            }
        }

     if(Input.GetButtonDown("Jump") && rb.velocity.y > 0f ) 
        {
        rb.velocity = new Vector2 (rb.velocity.x, rb.velocity.y * 0.6f);
        }


        Flip();

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }
    }


    private void FixedUpdate()
    {
        if (IsDashing)
        {
            return;
        }

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


    public bool canDash = true;
    private bool IsDashing;

    [SerializeField]
    private float DashPower;
    [SerializeField]
    private float DashTime;
    [SerializeField]
    private float DashCoolDown;


    private IEnumerator Dash()
    {
        canDash = false;
        IsDashing = true;
        float OrigGrav = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * DashPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        tr.emitting = false;
        rb.gravityScale = OrigGrav;
        IsDashing = false;
        yield return new WaitForSeconds(DashCoolDown);
        canDash = true;
    }
}
  

