using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAi : MonoBehaviour
{
    public Transform[] player, player2;
    public float speed = 3.0f;
    public float stoppingDistance = 2.0f;
    [SerializeField] float destroyDelay = 5f;
    // public int damageAmount = 10;
    //public playerHealth playerHealth1;
    // public CharacterController characterController;

    private Rigidbody2D rb;

    public GameObject explosion;

    SpriteRenderer sr;
    RobotAi Ai;

    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        Ai = GetComponent<RobotAi>();
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Collided with Player");
            
            explosion.gameObject.SetActive(true);
        }
    }




}
