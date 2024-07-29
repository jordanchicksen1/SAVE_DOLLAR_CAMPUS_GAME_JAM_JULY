using System.Collections;
using UnityEngine;

public class SinglePlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    public float horizontal;
    public float vertical;

    public Vector2 H;
    public Vector2 V;

    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Collider2D col2d;
    private SpriteRenderer spriteRenderer;
    public Mover movers;
    private void Start()
    {
        movers = GetComponent<Mover>();

        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<TrailRenderer>();
        col2d = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        BackLook.SetActive(false);
        FrontLook.SetActive(true);
        RightLook.SetActive(false);
        LeftLook.SetActive(false);
    }

    public GameObject RightLook;
    public GameObject LeftLook;
    public GameObject BackLook;
    public GameObject FrontLook;

    public GameObject Stop;

    public CharacterController characterControllers;
    public void Update()
    {

        if (IsDashing || IsFading)
        {
            return;
        }

       


        
        if (characterControllers.velocity.x > 0)
        {
            BackLook.SetActive(false);
            FrontLook.SetActive(false);
            RightLook.SetActive(true);
            LeftLook.SetActive(false);
            Stop.SetActive(false);

        }

        if (characterControllers.velocity.y > 0)
        {
            BackLook.SetActive(true);
            FrontLook.SetActive(false);
            RightLook.SetActive(false);
            LeftLook.SetActive(false);
            Stop.SetActive(false);

        }
        if (characterControllers.velocity.y < 0)
        {
            BackLook.SetActive(false);
            FrontLook.SetActive(true);
            RightLook.SetActive(false);
            LeftLook.SetActive(false);
            Stop.SetActive(false);

        }
        if (characterControllers.velocity.x < 0)
        {
            BackLook.SetActive(false);
            FrontLook.SetActive(false);
            RightLook.SetActive(false);
            LeftLook.SetActive(true);
            Stop.SetActive(false);

        }

        if (characterControllers.velocity.y == 0 && characterControllers.velocity.x == 0)
        {
            BackLook.SetActive(false);
            FrontLook.SetActive(false);
            RightLook.SetActive(false);
            LeftLook.SetActive(false);
            Stop.SetActive(true);
        }




        // Normalize the direction to ensure consistent movement speed
        Vector2 moveDirection = new Vector2(horizontal, vertical).normalized;
        horizontal = moveDirection.x;
        vertical = moveDirection.y;

        //Flip();

        if (Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.E) && canFade)
        {
            StartCoroutine(Fade());
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            AbilitySwitch();
        }
    }

    private void FixedUpdate()
    {
        if (IsDashing || IsFading)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
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

    public bool FadeAbility = false;

    private bool canFade = true;
    private bool IsFading;

    [SerializeField]
    private float FadePower;
    [SerializeField]
    private float FadeTime;
    [SerializeField]
    private float FadeCoolDown;

    private IEnumerator Dash()
    {
        if (DashAbility)
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
            rb.gravityScale = OrigGrav;
            IsDashing = false;
            yield return new WaitForSeconds(DashCoolDown);
            canDash = true;
        }
    }

    private IEnumerator Fade()
    {
        if (FadeAbility)
        {
            canFade = false;
            IsFading = true;
            col2d.enabled = false;
            float OrigGrav = rb.gravityScale;
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(transform.localScale.x * FadePower, 0f);
            tr.emitting = true;
            tr.startColor = Color.white;
            yield return new WaitForSeconds(FadeTime);
            tr.emitting = false;
            rb.gravityScale = OrigGrav;
            IsFading = false;
            col2d.enabled = true;
            yield return new WaitForSeconds(FadeCoolDown);
            canFade = true;
        }
    }

    public void AbilitySwitch()
    {
        if (DashAbility)
        {
            Debug.Log("Switch to Fade");
            DashAbility = false;
            FadeAbility = true;
        }
        else if (FadeAbility)
        {
            Debug.Log("Switch to Dash");
            FadeAbility = false;
            DashAbility = true;
        }
    }
}
