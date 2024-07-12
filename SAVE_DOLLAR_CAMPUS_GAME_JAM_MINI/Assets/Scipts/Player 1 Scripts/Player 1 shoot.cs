using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Player1shoot : MonoBehaviour
{
    public PotionSpawner SpawnerScript;
    public GameObject Gun;
    private Rigidbody2D rb;
    public List<GameObject> Potion;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.transform.parent = Gun.transform;
            collision.gameObject.transform.position = Gun.transform.position;
            collision.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
           

        }
    }
    private void Start()
    {
        rb = Potion[0].GetComponent<Rigidbody2D>();
    }

    public float Speed = 5f;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (rb != null)
            {
                rb.velocity =  transform.right * Speed;
            }
        }
    }
}
