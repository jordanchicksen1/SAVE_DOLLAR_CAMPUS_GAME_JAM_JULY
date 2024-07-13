using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Ammo"))
            {
            Destroy(collision.gameObject);
            Debug.Log("Should Destroy");

        }

        if (collision.gameObject.CompareTag("Player2Ammo"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Should Destroy");
        }
    }
}
