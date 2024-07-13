using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player1Grab : MonoBehaviour
{
    public int Health = 10;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2Ammo"))
        {
            Health--;
            Destroy(collision.gameObject);
        }
    }

}
