using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 5f; 

    void Update()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }

        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
