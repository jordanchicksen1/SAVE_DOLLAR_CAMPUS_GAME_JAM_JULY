using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RobotAi : MonoBehaviour
{
    public Transform[] player, player2;
    public float speed = 3.0f;
    public float stoppingDistance = 2.0f;
   // public int damageAmount = 10;
    //public playerHealth playerHealth1;
   // public CharacterController characterController;

    private Rigidbody2D rb;
  
    //public GameObject spriteUp;
    //public GameObject spriteDown;
   // public GameObject spriteLeft;
    //public GameObject spriteRight;

   // public bool isActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player[0].position);
        if (distanceToPlayer < stoppingDistance)
        {
            Vector2 direction = (player[0].position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }

        float distanceToPlayer2 = Vector2.Distance(transform.position, player2[0].position);
        if (distanceToPlayer2 < stoppingDistance)
        {
            Vector2 direction = (player2[0].position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }

        // if (rb.velocity.x > 0)
        // {
        //    // Moving right
        //   spriteRight.SetActive(true);
        //   spriteLeft.SetActive(false);
        //    spriteUp.SetActive(false);
        //      spriteDown.SetActive(false);
        // }
        /// else if (rb.velocity.x < 0)
        // {
        // Moving left
        //  spriteRight.SetActive(false);
        //   spriteLeft.SetActive(true);
        //     spriteUp.SetActive(false);
        //    spriteDown.SetActive(false);
        //  }

        // if (rb.velocity.y > 0)
        // {
        // Moving up
        //   spriteRight.SetActive(false);
        //    spriteLeft.SetActive(false);
        //    spriteUp.SetActive(true);
        //      spriteDown.SetActive(false);
        //  }
        //else if (rb.velocity.y < 0)
        // {
        //    // Moving down
        //   spriteRight.SetActive(false);
        //   spriteLeft.SetActive(false);
        //   spriteUp.SetActive(false);
        //    spriteDown.SetActive(true);
        // }

        Debug.Log(rb.velocity.x);
        Debug.Log(speed);
    }
}

   

 





