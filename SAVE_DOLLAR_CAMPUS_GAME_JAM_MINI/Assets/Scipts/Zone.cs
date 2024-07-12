using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    public float maxScale = 5f;
    public float minScale = 1f;

    public Vector2 temp;
    public bool increasing = true;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        temp = transform.localScale;
    }

    void Update()
    {
        if (increasing)
        {
            if (temp.x < maxScale && temp.y < maxScale)
            {
                temp.x += Time.deltaTime * speed;
                temp.y += Time.deltaTime * speed;
            }
            else
            {
                increasing = false;
            }
        }
        else
        {
            if (temp.x > minScale && temp.y > minScale)
            {
                temp.x -= Time.deltaTime * speed;
                temp.y -= Time.deltaTime * speed;
            }
            else
            {
                increasing = true;
            }
        }

        transform.localScale = temp;
    }
      
}
