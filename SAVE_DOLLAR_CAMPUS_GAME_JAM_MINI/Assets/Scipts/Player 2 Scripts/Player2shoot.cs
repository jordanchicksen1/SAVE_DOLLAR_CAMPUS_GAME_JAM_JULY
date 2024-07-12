using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2shoot : MonoBehaviour
{

    public PotionSpawner SpawnerScript;
    public GameObject Gun;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.transform.parent = Gun.transform;
            SpawnerScript.Items.Add(collision.gameObject);
            collision.gameObject.transform.position = Gun.transform.position;
            collision.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);

        }
    }
}
