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
        float RotationX = 0;
        float RotationY = 0;
        float RotationZ = 0;


        if (Input.GetButton("R1"))
        {
            RotationZ = -RotationSpeed * Time.deltaTime;
        }
        if (Input.GetButton("L1"))
        {
            RotationZ = RotationSpeed * Time.deltaTime;
        }
       

        transform.Rotate(RotationX, RotationY, RotationZ);



    }
}
