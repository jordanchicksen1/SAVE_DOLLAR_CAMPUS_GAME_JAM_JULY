using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    private Keyboard Player1Keyboard;
    [SerializeField]
    private float speed;

    private Vector2 movement;
    void Start()
    {
        Player1Keyboard = InputSystem.devices[0] as Keyboard;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Keyboard != null)
        {
            movement.x = (Player1Keyboard.aKey.isPressed ? -1 : 0) + (Player1Keyboard.dKey.isPressed ? 1 : 0);
            movement.y = (Player1Keyboard.sKey.isPressed ? -1 : 0) + (Player1Keyboard.wKey.isPressed ? 1 : 0);

            Vector3 move = new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);
            transform.Translate(move);
        }
    }
}
