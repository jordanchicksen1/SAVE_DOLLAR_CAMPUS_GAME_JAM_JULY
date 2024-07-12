using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Grab : MonoBehaviour
{
    public Transform Player2;

    public bool CanCarry = false;
    public bool carrying = false;

    private GameObject Items;


    void Start()
    {
        Items = GameObject.FindGameObjectWithTag("Item");
        OriginalParent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            carrying = true;
        }
        else if (Input.GetKeyUp(KeyCode.KeypadEnter))
        {
            carrying = false;

        }



        if (CanCarry == true && carrying == true)
        {
            Items.gameObject.transform.SetParent(Player2);
            Items.gameObject.transform.position = Bag.transform.position;
        }
        else if (carrying == false)
        {
            Items.gameObject.transform.SetParent(OriginalParent);

        }

    }
    public Transform Bag;


    private Transform OriginalParent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            CanCarry = true;

        }

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {
            CanCarry = false;

        }

    }
}
