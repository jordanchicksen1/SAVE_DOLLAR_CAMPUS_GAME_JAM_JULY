using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float speed = 1f;
    public float maxScale = 5f;
    public float minScale = 0f;

    Vector2 temp;
   

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (temp.x < maxScale  &&  temp.y < minScale)
        {
            temp = transform.localScale;
            temp.x -= Time.deltaTime * speed;
            temp.y -= Time.deltaTime * speed;
            transform.localScale = temp;
        }
      

    }
}
