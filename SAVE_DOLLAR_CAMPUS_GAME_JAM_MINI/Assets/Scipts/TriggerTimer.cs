using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTimer : MonoBehaviour
{
    [SerializeField]
    private float Timer;

    [SerializeField]
    private float MaxTime;

    public GameObject Tp3;
    public Rigidbody2D rb;
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("Area");
        Timer += Time.deltaTime;

        if (Timer > MaxTime) 
        {
        rb.transform.position = Tp3.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Timer = 0;
    }
}
