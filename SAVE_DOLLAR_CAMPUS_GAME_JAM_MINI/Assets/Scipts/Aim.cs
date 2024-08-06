using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Pun;

public class RightStickRotation : MonoBehaviour
{
    public float rotationSpeed = 100f; // Adjust the rotation speed as needed
    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();  
    }

    void Update()
    {


        
            LookAround();
        
        

        
    }

    private void LookAround()
    {
        if (view.IsMine)
        {
            // Get horizontal and vertical look inputs from the right joystick
            float lookX = Input.GetAxis("RightStickZ");

            // Horizontal rotation: Rotate the player object around the y-axis
            transform.Rotate(0, 0, lookX * rotationSpeed * Time.deltaTime);

            // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping


            // Apply the clamped vertical rotation to the player camera
            Debug.Log(lookX);
        }

    }
}
