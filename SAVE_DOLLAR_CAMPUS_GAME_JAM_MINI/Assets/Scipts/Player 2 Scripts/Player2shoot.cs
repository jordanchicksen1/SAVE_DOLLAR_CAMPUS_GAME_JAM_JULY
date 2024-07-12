using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2shoot : MonoBehaviour
{

    public GameObject Gun;
    private Rigidbody2D rb;
    public List<GameObject> Potion;
    public Transform Test;


    private void Start()
    {
        Potion = new List<GameObject>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
           // gameObject.tag = "Player1Ammo";

            GameObject collected = collision.gameObject;
            collected.transform.parent = Gun.transform;
            collected.transform.position = Gun.transform.position;
            collected.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            collected.tag = "Player1Ammo";
            Potion.Add(collected);

            
        }
        if (collision.gameObject.CompareTag("Player2Ammo"))
        {
            Debug.Log("IT Works");
        }
    }

    private void Update()
    {
        if (Potion.Count > 0 && Input.GetKeyUp(KeyCode.RightControl))
        {
            GameObject BulletSpawn = Potion[0];
            GameObject Shot = Instantiate(BulletSpawn, Gun.transform.position, Quaternion.identity);
            Rigidbody2D SH = Shot.GetComponent<Rigidbody2D>();

            if (SH != null)
            {
                SH.velocity = Test.up * -10;
                Potion.Clear(); // Clear the list after shooting
            }

            

            if (Potion.Count == 0)
            {
                Destroy(BulletSpawn);
                //  Destroy(Shot);
            }
        }

        if (Potion.Count >1 )
        {
            Potion.RemoveAt(0);
        }

    }
}
