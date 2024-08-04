using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer1Rotate : MonoBehaviour
{
    [SerializeField]
    private int RotationSpeed = 90;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
            // Get input from the right joystick
            float horizontal = Input.GetAxis("RightStickHorizontal");
            float vertical = Input.GetAxis("RightStickVertical");

            // Calculate the rotation vector
            Vector3 rotation = new Vector3(0, 0, horizontal);

            // Apply the rotation
            transform.Rotate(rotation * RotationSpeed * Time.deltaTime);
        


    }
}
