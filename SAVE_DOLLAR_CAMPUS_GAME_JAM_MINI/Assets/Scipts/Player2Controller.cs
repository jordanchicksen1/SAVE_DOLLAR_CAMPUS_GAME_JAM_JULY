using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    private Keyboard Player2Keyboard;
    [SerializeField]
    private float speed;

    private Vector2 movement;
    void Start()
    {
        Player2Keyboard = InputSystem.devices[1] as Keyboard;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player2Keyboard != null)
        {
            movement.x = (Player2Keyboard.aKey.isPressed ? -1 : 0) + (Player2Keyboard.dKey.isPressed ? 1 : 0);
            movement.y = (Player2Keyboard.sKey.isPressed ? -1 : 0) + (Player2Keyboard.wKey.isPressed ? 1 : 0);

            Vector3 move = new Vector3(movement.x * speed * Time.deltaTime, movement.y * speed * Time.deltaTime, 0);
            transform.Translate(move);
        }
    }
}
