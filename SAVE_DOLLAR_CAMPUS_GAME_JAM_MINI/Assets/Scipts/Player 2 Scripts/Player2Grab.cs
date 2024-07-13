using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    public int Health = 10;
    public GameObject HPBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Ammo"))
        {
            Health--;
            Destroy(collision.gameObject);
            HPBar.transform.localScale -= new Vector3(0.1f, 0, 0);

        }

        if (collision.gameObject.CompareTag("BOT"))
        {
            Health--;
            Destroy(collision.gameObject);
            HPBar.transform.localScale -= new Vector3(0.2f, 0, 0);

        }
    }
}
