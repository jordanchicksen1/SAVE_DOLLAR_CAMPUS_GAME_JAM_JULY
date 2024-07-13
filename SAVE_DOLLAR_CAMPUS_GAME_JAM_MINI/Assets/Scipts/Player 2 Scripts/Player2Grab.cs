using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    public int Health = 10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Ammo"))
        {
            Health--;
            Destroy(collision.gameObject);
        }
    }
}
