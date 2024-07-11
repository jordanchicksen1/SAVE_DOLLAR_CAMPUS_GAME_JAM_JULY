using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMove : MonoBehaviour
{
    [SerializeField]
    float turnSpeed;
    [SerializeField]
    float moveSpeed;

    void FixedUpdate()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Translate(turnAmount, 0, 0);

        float movePace = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(0, movePace, 0);

    }
}

