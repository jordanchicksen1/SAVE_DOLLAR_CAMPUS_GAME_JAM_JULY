using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
   public float moveSpeed = 5f; 

    void Update()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection.y -= 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection.x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
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
