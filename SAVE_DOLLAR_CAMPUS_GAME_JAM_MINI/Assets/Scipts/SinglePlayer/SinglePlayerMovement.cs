using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed;

   

    public float jumpforce;

    public bool CanDoubleJump;
    public float SecondJumpForce;


    private bool isFacingRight = true;
    //public bool CanJump = true;


    private bool DoubleJumpAbiltiy;
   
    

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Collider2D col2d;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
  

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        col2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
         else if (DoubleJumpAbiltiy && CanDoubleJump) 
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

        AblitySwitch();
    }


    private bool canDash = true;
    private bool IsDashing;

    public bool DashAbility;

    [SerializeField]
    private float DashPower;
    [SerializeField]
    private float DashTime;
    [SerializeField]
    private float DashCoolDown;


    
    
    public bool Fade = false;



  


    [SerializeField]
    private float FadePower;
    [SerializeField]
    private float FadeTime;
    [SerializeField]
    private float FadeCoolDown;


    private IEnumerator Dash()
    {
        if(DashAbility) 
        {
            canDash = false;
            IsDashing = true;
            float OrigGrav = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * DashPower, 0f);
            tr.emitting = true;
            tr.startColor = Color.red;
            yield return new WaitForSeconds(DashTime);
            tr.emitting = false;
            tr.startColor = Color.red;
            rb.gravityScale = OrigGrav;
            IsDashing = false;
            yield return new WaitForSeconds(DashCoolDown);
            canDash = true;
        }
       

        if (Fade) 
        {
            canDash = false;
            IsDashing = true;
            col2d.enabled = false;
            float OrigGrav = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * FadePower, 0f);
            tr.emitting = true;
            tr.startColor = Color.white;
            yield return new WaitForSeconds(FadeTime);
            tr.emitting = false;
            tr.endColor = Color.white;
            rb.gravityScale = OrigGrav;
            IsDashing = false;
            col2d.enabled = true;   
            yield return new WaitForSeconds(FadeCoolDown);
            canDash = true;
        }
    }

   public void AblitySwitch() 
    {
    if (Input.GetKeyDown(KeyCode.R)) 
        {
            if (DashAbility) 
            {
                Debug.Log("switch To Fade");
                DashAbility = false;
                Fade = true;
                return;
            }

            if (Fade) 
            {
                Debug.Log("switch To Dash");
                Fade = false;
                DashAbility = true;
                return;
            }
        }
    }
}
  


