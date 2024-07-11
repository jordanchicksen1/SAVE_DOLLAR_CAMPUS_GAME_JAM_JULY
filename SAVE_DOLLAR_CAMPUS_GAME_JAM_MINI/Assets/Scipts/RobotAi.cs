using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAi : MonoBehaviour
{
    public Transform player;
    public float speed = 3.0f;
    public float stoppingDistance = 2.0f;
    public int damageAmount = 10;  // Amount of damage to deal
   //ublic playerHealth playerHealth1;
    public CharacterController characterController;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <stoppingDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

 
}
