using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTeleporter : MonoBehaviour
{
  
    public Rigidbody2D rb;
    public GameObject teleporter2;
    private void OnTriggerEnter2D(Collider2D other)
    {
           rb.transform.position = teleporter2.transform.position;
            Debug.Log("tp");
    }
}
