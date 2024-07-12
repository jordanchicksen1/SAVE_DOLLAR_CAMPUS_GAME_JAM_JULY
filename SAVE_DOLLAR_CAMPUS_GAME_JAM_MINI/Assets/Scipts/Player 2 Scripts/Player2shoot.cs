using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2shoot : MonoBehaviour
{

    public GameObject Ammo;
    private Rigidbody2D rb;
    public int speed = 5;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            GameObject Bullet = Instantiate(Ammo, transform.position, Quaternion.identity);
            Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * speed;
            }
        }
    }
}
