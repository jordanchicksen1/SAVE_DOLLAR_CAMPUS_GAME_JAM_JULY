using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1.0f;
    [SerializeField] float moveSpeed = 0.01f;
   //ublic enemyHealth enemyHealth;
    //blic RichRunAway[] richRunAway;
    public int damageAmount = 10;
    void Start()
    {

    }
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

  
   
}
