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

            Tester1 = true;
            Count++;
            if (Tester1 == true && Count == 1)
            {
                GameObject collected = collision.gameObject;
                collected.transform.parent = Gun.transform;
                collected.transform.position = Gun.transform.position;
                collected.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                collected.tag = "Player2Ammo";
                Potion.Add(collected);
                Tester1 = false;
            }
            else 
                {
              

                return; 
                }

            



        }
        
    }
    public bool Tester1 = false;

    public int Count;
    private void Update()
    {

        if (Potion.Count < 1)
        {
            Tester1 = false;
            Count = 0;
        }

        if (Potion[0] == null)
        {
            Potion.Clear();
        }

        if (Potion.Count > 0 && Input.GetKeyUp(KeyCode.RightControl))
        {
            GameObject BulletSpawn = Potion[0];
            GameObject Shot = Instantiate(BulletSpawn, Gun.transform.position, Quaternion.identity);
            Rigidbody2D SH = Shot.GetComponent<Rigidbody2D>();

            if (SH != null)
            {
                SH.velocity = Test.up * -10;
                Potion.Clear(); // Clear the list after shooting
                Count = 0;

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

        if (Count < 0)
        {
            Count = 0;
        }

    }
}
