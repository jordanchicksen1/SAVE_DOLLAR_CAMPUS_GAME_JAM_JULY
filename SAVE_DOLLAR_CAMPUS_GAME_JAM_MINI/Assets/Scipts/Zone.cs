using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    public float speed = 1f;
    public float maxScale = 5f;
    public float minScale = 0f;

    Vector2 temp;
    bool isGrowing = true;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        temp = transform.localScale;

        if (isGrowing)
        {
            // Increase scale
            temp.x += Time.deltaTime * speed;
            temp.y += Time.deltaTime * speed;

            // Check if we have reached the maximum scale
            if (temp.x >= maxScale && temp.y >= maxScale)
            {
                isGrowing = false; // Switch to shrinking
            }
        }
        else
        {
            // Decrease scale
            temp.x -= Time.deltaTime * speed;
            temp.y -= Time.deltaTime * speed;

            // Check if we have reached the minimum scale
            if (temp.x <= minScale && temp.y <= minScale)
            {
                isGrowing = true; // Switch to growing
            }
        }

        transform.localScale = temp;
    }
}
