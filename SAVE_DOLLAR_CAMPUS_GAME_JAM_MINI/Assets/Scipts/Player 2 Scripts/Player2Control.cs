using System.Collections;
using UnityEngine;

public class PLayer2Control : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    private float horizontal;
    private float vertical;

    private bool isFacingRight = true;

    private Rigidbody2D rb;
    private TrailRenderer tr;
    private Collider2D col2d;
    private SpriteRenderer spriteRenderer;
    private Mover movers;

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

    private void Update()
    {
        if (IsDashing || IsFading)
        {
            return;
        }

        // Check for key presses and adjust the movement variables accordingly
        horizontal = 0f;
        vertical = 0f;

        if (Input.GetKey(KeyCode.Keypad8) || movers.inputVector.y > 0)
        {
            vertical = 1f;
            BackLook.SetActive(true);
            FrontLook.SetActive(false);
            RightLook.SetActive(false);
            LeftLook.SetActive(false);

        }
        if (Input.GetKey(KeyCode.Keypad5) || movers.inputVector.y < 0)
        {
            vertical = -1f;
            BackLook.SetActive(false);
            FrontLook.SetActive(true);
            RightLook.SetActive(false);
            LeftLook.SetActive(false);

        }
        if (Input.GetKey(KeyCode.Keypad4) || movers.inputVector.x < 0)
        {
            horizontal = -1f;
            BackLook.SetActive(false);
            FrontLook.SetActive(false);
            RightLook.SetActive(false);
            LeftLook.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Keypad6) || movers.inputVector.x > 0)
        {
            horizontal = 1f;
            BackLook.SetActive(false);
            FrontLook.SetActive(false);
            RightLook.SetActive(true);
            LeftLook.SetActive(false);
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

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
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
